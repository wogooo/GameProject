﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using UniLua;
using System.Collections;
 
public class Module_OOSyncClient : IModule
{
    public IEnumerator Init()
    {
        //创造单例
        OOSync.OOSyncClient.AutoInstance();

        yield break;
    }
} 