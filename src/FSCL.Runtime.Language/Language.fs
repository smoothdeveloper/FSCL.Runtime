﻿namespace FSCL
open System
open System.Collections.Generic
open FSCL.Language
open FSCL.Compiler

module Language =
    // Kernel run mode
    type RunningMode =
    | OpenCL
    | Multithread
    | Sequential
    
    // BufferReusePriority
    type BufferSharePriority =
    | PriorityToFlags
    | PriorityToShare

    // BufferPoolPersistency
    // PersistencyInsideExpression: tracked buffer are reused among the kernels executed inside the same expression
    // but are disposed when the Run method ends
    // PersistencyAcrossExpressions: tracked buffers are never disposed and can be reused across different expressions
    type BufferPoolPersistency =
    | PersistencyInsideExpression
    | PersistencyAcrossExpressions

    ///
    ///<summary>
    ///The attribute to specify a device
    ///</summary>
    ///
    [<AllowNullLiteral>]
    type DeviceAttribute(plat: int, dev: int) =
        inherit KernelMetadataAttribute()
        member val Platform = plat with get
        member val Device = dev with get
        new() =
            DeviceAttribute(0, 0)   
             
    ///
    ///<summary>
    ///The attribute to specify a device
    ///</summary>
    ///
    [<AllowNullLiteral>]
    type RunningModeAttribute(mode: RunningMode) =
        inherit KernelMetadataAttribute()
        member val RunningMode = mode with get
        new() =
            RunningModeAttribute(RunningMode.OpenCL)   
                
    ///
    ///<summary>
    ///The attribute to specify multithread fallback
    ///</summary>
    ///
    [<AllowNullLiteral>]
    type MultithreadFallbackAttribute(fallback: bool) =
        inherit KernelMetadataAttribute()
        member val Fallback = fallback with get
        new() =
            MultithreadFallbackAttribute(true)   

    ///
    ///<summary>
    ///The attribute to specify a device
    ///</summary>
    (*
    [<AllowNullLiteral>]
    type WorkSizeAttribute(globalSize: int64 array, localSize: int64 array, globalOffset: int64 array) =
        inherit KernelMetadataAttribute()
        member val GlobalSize = globalSize with get
        member val LocalSize = localSize with get
        member val GlobalOffset = globalOffset with get
        new(globalSize: int64, localSize: int64, globalOffset: int64) =
            WorkSizeAttribute([| globalSize |], [| localSize |], [| globalOffset |])  
        new() =
            WorkSizeAttribute([| 0L |], [| 0L |], [| 0L |])   
      *)      
    // Functions matching attributes for dynamic marking of parameters
    [<MetadataFunction(typeof<DeviceAttribute>, MetadataFunctionTarget.KernelFunction)>]
    let DEVICE(plat: int, dev: int, a) = 
        a
        (*
    [<KernelMetadataFunction(typeof<WorkSizeAttribute>)>]
    let WORKSIZE(globalSize: int64 array, localSize: int64 array, a) = 
        a
        *)

    [<MetadataFunction(typeof<RunningModeAttribute>, MetadataFunctionTarget.KernelFunction)>]
    let RUNNING_MODE(mode: RunningMode, a) = 
        a
                
    [<MetadataFunction(typeof<MultithreadFallbackAttribute>, MetadataFunctionTarget.KernelFunction)>]
    let MULTITHREAD_FALLBACK(fallback: bool, a) = 
        a



