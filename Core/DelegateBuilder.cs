using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Core {
    public class DelegateBuilder {
        public Action Build(Type type, MethodInfo methodInfo) {

            Expression create = Expression.New(type.GetConstructor(new Type[] {}));
            Action action = Expression.Lambda<Action>(Expression.Call(create, methodInfo)).Compile();
            
            return action;
        }

        public Action Build2(Type type, MethodInfo methodInfo) {
            object @object = Activator.CreateInstance(type);
            return (Action) Delegate.CreateDelegate(typeof (Action), @object, methodInfo);
        }
    }
}