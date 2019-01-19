//
//  ThreadExtension.cs
//  Sakura
//
//  Created by LunarEclipse on 2019-01-19 07:20:51.
//  Copyright © 2019 LunarEclipse. All rights reserved.
//

using System.Threading;

namespace Sakura.Extensions
{
    public static class ThreadExtension
    {
        // Do this when you start your application
        private static int MAIN_THREAD_ID = Thread.CurrentThread.ManagedThreadId;

        public static bool IsMain(this Thread thread)
        {
            return thread.ManagedThreadId == MAIN_THREAD_ID;
        }
    }
}