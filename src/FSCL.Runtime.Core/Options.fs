﻿namespace FSCL.Runtime

open System

module RuntimeOptions = 
    [<Literal>]
    let UseCache = "UseCache"
    [<Literal>]
    let BufferPoolPersistency = "BufferPoolPersistency"
    [<Literal>]
    let RunningMode = "RunningMode"
    [<Literal>]
    let WorkSize = "WorkSize"
    [<Literal>]
    let MultithreadFallback = "MultithreadFallback"
    [<Literal>]
    let BufferSharePriority = "BufferSharePriority"

    // Internal options
    [<Literal>]
    let CreateOnly = "CreateOnly"



