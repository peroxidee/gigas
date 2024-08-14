using System;
using System.Runtime.InteropServices;

namespace gigas
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PEB
    {
        public bool InheritedAddressSpace;
        public bool ReadImageFileExecOptions;
        public bool BeingDebugged;

        [StructLayout(LayoutKind.Explicit)]
        public struct BitFieldUnion
        {
            [FieldOffset(0)] public byte BitField;

            [FieldOffset(0)]
            public struct BitFieldStruct
            {
                public byte ImageUsesLargePages : 1;
                public byte IsProtectedProcess : 1;
                public byte IsImageDynamicallyRelocated : 1;
                public byte SkipPatchingUser32Forwarders : 1;
                public byte IsPackagedProcess : 1;
                public byte IsAppContainer : 1;
                public byte IsProtectedProcessLight : 1;
                public byte IsLongPathAwareProcess : 1;
            }

            public BitFieldStruct Fields;
        }

        public BitFieldUnion FlagsUnion;

        public IntPtr Mutant;
        public IntPtr ImageBaseAddress;
        public IntPtr Ldr; // Pointer to PEB_LDR_DATA
        public IntPtr ProcessParameters; // Pointer to RTL_USER_PROCESS_PARAMETERS
        public IntPtr SubSystemData;
        public IntPtr ProcessHeap;
        public IntPtr FastPebLock;
        public IntPtr AtlThunkSListPtr;
        public IntPtr IFEOKey;

        [StructLayout(LayoutKind.Explicit)]
        public struct CrossProcessFlagsUnion
        {
            [FieldOffset(0)] public uint CrossProcessFlags;

            [FieldOffset(0)]
            public struct CrossProcessFlagsStruct
            {
                public uint ProcessInJob : 1;
                public uint ProcessInitializing : 1;
                public uint ProcessUsingVEH : 1;
                public uint ProcessUsingVCH : 1;
                public uint ProcessUsingFTH : 1;
                public uint ProcessPreviouslyThrottled : 1;
                public uint ProcessCurrentlyThrottled : 1;
                public uint ProcessImagesHotPatched : 1;
                public uint ReservedBits0 : 24;
            }

            public CrossProcessFlagsStruct Flags;
        }

        public CrossProcessFlagsUnion CrossProcessFlags;

        public IntPtr KernelCallbackTable;
        public uint SystemReserved;
        public uint AtlThunkSListPtr32;
        public IntPtr ApiSetMap;
        public uint TlsExpansionCounter;
        public IntPtr TlsBitmap;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TlsBitmapBits; // TLS_MINIMUM_AVAILABLE

        public IntPtr ReadOnlySharedMemoryBase;
        public IntPtr SharedData; // Pointer to SILO_USER_SHARED_DATA
        public IntPtr ReadOnlyStaticServerData;
        public IntPtr AnsiCodePageData;
        public IntPtr OemCodePageData;
        public IntPtr UnicodeCaseTableData;

        public uint NumberOfProcessors;
        public uint NtGlobalFlag;

        public ulong CriticalSectionTimeout;
        public IntPtr HeapSegmentReserve;
        public IntPtr HeapSegmentCommit;
        public IntPtr HeapDeCommitTotalFreeThreshold;
        public IntPtr HeapDeCommitFreeBlockThreshold;

        public uint NumberOfHeaps;
        public uint MaximumNumberOfHeaps;
        public IntPtr ProcessHeaps;

        public IntPtr GdiSharedHandleTable;
        public IntPtr ProcessStarterHelper;
        public uint GdiDCAttributeList;

        public IntPtr LoaderLock;

        public uint OSMajorVersion;
        public uint OSMinorVersion;
        public ushort OSBuildNumber;
        public ushort OSCSDVersion;
        public uint OSPlatformId;
        public uint ImageSubsystem;
        public uint ImageSubsystemMajorVersion;
        public uint ImageSubsystemMinorVersion;
        public ulong ActiveProcessAffinityMask;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 34)]
        public uint[] GdiHandleBuffer;

        public IntPtr PostProcessInitRoutine;

        public IntPtr TlsExpansionBitmap;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public uint[] TlsExpansionBitmapBits; // TLS_EXPANSION_SLOTS

        public uint SessionId;

        public ulong AppCompatFlags;
        public ulong AppCompatFlagsUser;
        public IntPtr pShimData;
        public IntPtr AppCompatInfo;

        public UNICODE_STRING CSDVersion;

        public IntPtr ActivationContextData;
        public IntPtr ProcessAssemblyStorageMap;
        public IntPtr SystemDefaultActivationContextData;
        public IntPtr SystemAssemblyStorageMap;

        public IntPtr MinimumStackCommit;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public IntPtr[] SparePointers;

        pub
    }
    public struct VX_TABLE_ENTRY { 
        public IntPtr pAddress;
        public uint dwHash;
        public ushort wSystemCall;
    } 
    public struct VX_TABLE {
        public VX_TABLE_ENTRY NtAllocateVirtualMemory;
        public VX_TABLE_ENTRY NtWriteVirtualMemory;
        public VX_TABLE_ENTRY NtCreateThreadEx;
    }

}