﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

#if HAS_EDI
namespace System.Reactive.PlatformServices
{
  //
  // WARNING: This code is kept *identically* in two places. One copy is kept in System.Reactive.Core for non-PLIB platforms.
  //          Another copy is kept in System.Reactive.PlatformServices to enlighten the default lowest common denominator
  //          behavior of Rx for PLIB when used on a more capable platform.
  //
  internal class DefaultExceptionServices/*Impl*/ : IExceptionServices
  {
    public void Rethrow(Exception exception)
    {
#if NET40
      throw System.Runtime.ExceptionServices.ExceptionEnlightenment.PrepareForRethrow(exception);
#else
      System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(exception).Throw();
#endif
    }
  }
}
#else
  namespace System.Reactive.PlatformServices
{
    internal class DefaultExceptionServices : IExceptionServices
    {
        public void Rethrow(Exception exception)
        {
            throw exception;
        }
    }
}
#endif