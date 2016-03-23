﻿/**
 * @interface strange.extensions.injector.api.IInjectionBinding
 * 
 * The Binding form for the Injection system.
 * 
 * The InjectionBinding allows mapping to three core types:
 * <ul>
 *  <li>Default: every `GetInstance()` on the Binder Key returns a new imstance</li>
 *  <li>ToSingleton: every `GetInstance()` on the Binder Key returns the same imstance</li>
 *  <li>ToValue: every `GetInstance()` on the Binder Key returns the provided imstance</li>
 * </ul>
 * 
 * Named injections are supported, thus:
 * 
    Bind<IMyInterface>().To<MyInterfaceImplementer>().ToName(SomeEnum.VALUE);
 * 
 * returns a MyInterfaceImplementer instance only to injections that specifically tag
 * SomeEnum.Value. This will be the same instance whenever it is called.
 * 
 * You can also map multiple Keys, allowing for polymorphic binding.
 * This allows you to match two or more interfaces to a single class or value.
 * 
    Bind<IFirstInterface>().Bind<ISecondInterface>().To<PolymorphicClass>();
 * 
 * Note that while you can bind multiple keys to an InjectionBinding, you can
 * only bind one value. (The Injection system needs to know which concrete
 * class you want created.)
 * 
 * @see strange.extensions.injector.api.IInjectionBinder
 */

using System;
using strange.framework.api;

namespace strange.extensions.injector.api
{
  public interface IInjectionBinding : IBinding
  {
    /// Map the Binding to a Singleton so that every `GetInstance()` on the Binder Key returns the same imstance.
    IInjectionBinding ToSingleton ();

    /// Map the Binding to a stated instance so that every `GetInstance()` on the Binder Key returns the provided imstance. Sets type to Value
    IInjectionBinding ToValue (object o);

    /// Map the Binding to a stated instance so that every `GetInstance()` on the Binder Key returns the provided imstance. Does not set type.
    IInjectionBinding SetValue (object o);

    /// Map the binding and give access to all contexts in hierarchy
    IInjectionBinding CrossContext ();

    bool isCrossContext { get; }

    /// Boolean setter to optionally override injection. If false, the instance will not be injected after instantiation.
    IInjectionBinding ToInject (bool value);

    /// Get the parameter that specifies whether this Binding allows an instance to be injected
    bool toInject { get; }

    /// Get and set the InjectionBindingType
    /// @see InjectionBindingType
    InjectionBindingType type { get; set; }

    /// Bind is the same as Key, but permits Binder syntax: `Bind<T>().Bind<T>()`
    new IInjectionBinding Bind<T> ();

    /// Bind is the same as Key, but permits Binder syntax: `Bind<T>().Bind<T>()`
    new IInjectionBinding Bind (object key);

    new IInjectionBinding To<T> ();

    new IInjectionBinding To (object o);

    new IInjectionBinding ToName<T> ();

    new IInjectionBinding ToName (object o);

    new IInjectionBinding Named<T> ();

    new IInjectionBinding Named (object o);


    new object key { get; }

    new object name { get; }

    new object value { get; }

    new Enum keyConstraint { get; set; }

    new Enum valueConstraint { get; set; }
  }
}
