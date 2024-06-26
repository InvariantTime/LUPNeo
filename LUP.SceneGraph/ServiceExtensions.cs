﻿using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.SceneGraph.Components;
using LUP.SceneGraph.Components.Middlewares;
using LUP.SceneGraph.Modules;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public static class ServiceExtensions
    {
        public static void AddSceneSystem(this IServiceCollection services)
        {
            //scene core
            services.RegisterType<SceneProcessor>()
                .As<ISceneProcessor>().AsSelf()
                .AsSingleton();

            services.RegisterType<ObjectBuilder>()
                .As<IObjectBuilder>().AsScoped();

            services.RegisterType<SceneBuilder>()
                .As<ISceneBuilder>().AsSelf()
                .AsSingleton();

            services.RegisterType<Scene>()
                .As<IScene>().AsSelf()
                .OnActivated(InitilaizeScene).AsScoped();

            services.RegisterType<RootObjectScope>()
                .As<IRootObjectScope>().AsSelf()
                .AsScoped();

            services.RegisterType<ModuleScope>()
                .As<IModuleScope>().AsSelf()
                .AsScoped();

            //Component pipeline
            services.RegisterType<ComponentPipelineBuilder>()
                .AsSelf().AsScoped()
                .OnActivated((x) =>
                {
                    var initializers = x.Scope.GetService<IEnumerable<IComponentPipelineInitializer>>()
                        ?? Enumerable.Empty<IComponentPipelineInitializer>();

                    foreach (var init in initializers)
                        init.Initialize(x.Instance);
                });

            services.RegisterFactory(BuildComponentPipeline)
                .AsSelf().As<ComponentPipeline>().AsScoped();

            //init
            services.AddComponentMiddleware<InitValidationMiddleware>();
            services.AddComponentMiddleware<InitializeComponentMiddleware>();
            services.AddComponentMiddleware<InitializeTransformMiddleware>();

            //uinit
            services.AddComponentMiddleware<RemoveValidationMiddleware>();
            services.AddComponentMiddleware<UninitializeMiddleware>();
        }


        public static void AddComponentMiddleware<T>(this IServiceCollection services) where T : IComponentMiddleware
        {
            services.RegisterType<T>()
                .As<IComponentMiddleware>().AsSelf()
                .AsScoped();
        }


        public static IRegistrationBuilder<T, ImplementRegistrationData<T>> 
            AddModule<T>(this IServiceCollection services) where T : SceneModule
        {
            var builder = services.RegisterType<T>()
                .As<SceneModule>().AsSelf()
                .AsScoped();

            if (typeof(IComponentPipelineInitializer).IsAssignableFrom(typeof(T)) == true)
            {
                builder.As<IComponentPipelineInitializer>();
            }
            else if (typeof(IComponentMiddleware).IsAssignableFrom(typeof(T)) == true)
            {
                builder.As<IComponentMiddleware>();
            }

            return builder;
        }


        private static void InitilaizeScene(ActivatedContext<Scene> context)
        {
            var modules = context.Scope.GetService<IModuleScope>();
            var objects = context.Scope.GetService<RootObjectScope>();

            context.Instance.Initialize(modules!, objects!);
        }


        private static IComponentPipeline BuildComponentPipeline(IServiceScope scope)
        {
            var builder = scope.GetService<ComponentPipelineBuilder>()
                ?? throw new InvalidOperationException("Unable to create pipeline");

            return builder.Build();
        }
    }
}
