﻿using System;
using Unity.Builder;
using Unity.Policy;
using Unity.Resolution;

namespace Unity.ObjectBuilder.BuildPlan.DynamicMethod
{
    public class DynamicMethodBuildPlan : IBuildPlanPolicy, IResolver
    {
        private readonly Delegate _buildMethod;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildMethod"></param>
        public DynamicMethodBuildPlan(Delegate buildMethod)
        {
            _buildMethod = buildMethod;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void BuildUp<TBuilderContext>(ref TBuilderContext context)
            where TBuilderContext : IBuilderContext
        {
            context.Existing = ((ResolveDelegate<TBuilderContext>)_buildMethod).Invoke(ref context);

        }

        public object Resolve<TContext>(ref TContext context) 
            where TContext : IResolveContext
        {
            return ((ResolveDelegate<TContext>)_buildMethod).Invoke(ref context);
        }
    }
}
