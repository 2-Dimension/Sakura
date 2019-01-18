//
//  ThreadMode.cs
//
//  Created by LunarEclipse on 1/18/2019 10:55:49 PM.
//  Copyright © 2019 LunarEclipse. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Text;

namespace Sakura.Core.Event
{
    public enum ThreadMode
    {
        DEFAULT,    // Subscriber will be called in the same thread.
        MAIN,       // Subscriber will be called in the main thread.
        BACKGROUND, // Subscriber will be called in the background thread.
        ASYNC       // Subscriber will be called in the different thread except main thread.
    }
}
