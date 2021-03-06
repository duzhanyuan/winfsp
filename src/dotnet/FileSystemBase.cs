/**
 * @file dotnet/FileSystemBase.cs
 *
 * @copyright 2015-2017 Bill Zissimopoulos
 */
/*
 * This file is part of WinFsp.
 *
 * You can redistribute it and/or modify it under the terms of the GNU
 * General Public License version 3 as published by the Free Software
 * Foundation.
 *
 * Licensees holding a valid commercial license may use this file in
 * accordance with the commercial license agreement provided with the
 * software.
 */

using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

using Fsp.Interop;

namespace Fsp
{

    public partial class FileSystemBase
    {
        /* types */
        public class DirectoryBuffer : IDisposable
        {
            ~DirectoryBuffer()
            {
                Dispose(false);
            }
            public void Dispose()
            {
                lock (this)
                    Dispose(true);
                GC.SuppressFinalize(true);
            }
            protected virtual void Dispose(bool disposing)
            {
                Api.FspFileSystemDeleteDirectoryBuffer(ref DirBuffer);
            }

            internal IntPtr DirBuffer;
        }

        /* operations */
        public virtual Int32 ExceptionHandler(Exception ex)
        {
            return STATUS_UNEXPECTED_IO_ERROR;
        }
        public virtual Int32 Init(Object Host)
        {
            return STATUS_SUCCESS;
        }
        public virtual Int32 Mounted(Object Host)
        {
            return STATUS_SUCCESS;
        }
        public virtual void Unmounted(Object Host)
        {
        }
        public virtual Int32 GetVolumeInfo(
            out VolumeInfo VolumeInfo)
        {
            VolumeInfo = default(VolumeInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 SetVolumeLabel(
            String VolumeLabel,
            out VolumeInfo VolumeInfo)
        {
            VolumeInfo = default(VolumeInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 GetSecurityByName(
            String FileName,
            out UInt32 FileAttributes/* or ReparsePointIndex */,
            ref Byte[] SecurityDescriptor)
        {
            FileAttributes = default(UInt32);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Create(
            String FileName,
            UInt32 CreateOptions,
            UInt32 GrantedAccess,
            UInt32 FileAttributes,
            Byte[] SecurityDescriptor,
            UInt64 AllocationSize,
            out Object FileNode,
            out Object FileDesc,
            out FileInfo FileInfo,
            out String NormalizedName)
        {
            FileNode = default(Object);
            FileDesc = default(Object);
            FileInfo = default(FileInfo);
            NormalizedName = default(String);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Open(
            String FileName,
            UInt32 CreateOptions,
            UInt32 GrantedAccess,
            out Object FileNode,
            out Object FileDesc,
            out FileInfo FileInfo,
            out String NormalizedName)
        {
            FileNode = default(Object);
            FileDesc = default(Object);
            FileInfo = default(FileInfo);
            NormalizedName = default(String);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Overwrite(
            Object FileNode,
            Object FileDesc,
            UInt32 FileAttributes,
            Boolean ReplaceFileAttributes,
            UInt64 AllocationSize,
            out FileInfo FileInfo)
        {
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual void Cleanup(
            Object FileNode,
            Object FileDesc,
            String FileName,
            UInt32 Flags)
        {
        }
        public virtual void Close(
            Object FileNode,
            Object FileDesc)
        {
        }
        public virtual Int32 Read(
            Object FileNode,
            Object FileDesc,
            IntPtr Buffer,
            UInt64 Offset,
            UInt32 Length,
            out UInt32 BytesTransferred)
        {
            BytesTransferred = default(UInt32);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Write(
            Object FileNode,
            Object FileDesc,
            IntPtr Buffer,
            UInt64 Offset,
            UInt32 Length,
            Boolean WriteToEndOfFile,
            Boolean ConstrainedIo,
            out UInt32 BytesTransferred,
            out FileInfo FileInfo)
        {
            BytesTransferred = default(UInt32);
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Flush(
            Object FileNode,
            Object FileDesc,
            out FileInfo FileInfo)
        {
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 GetFileInfo(
            Object FileNode,
            Object FileDesc,
            out FileInfo FileInfo)
        {
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 SetBasicInfo(
            Object FileNode,
            Object FileDesc,
            UInt32 FileAttributes,
            UInt64 CreationTime,
            UInt64 LastAccessTime,
            UInt64 LastWriteTime,
            UInt64 ChangeTime,
            out FileInfo FileInfo)
        {
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 SetFileSize(
            Object FileNode,
            Object FileDesc,
            UInt64 NewSize,
            Boolean SetAllocationSize,
            out FileInfo FileInfo)
        {
            FileInfo = default(FileInfo);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 CanDelete(
            Object FileNode,
            Object FileDesc,
            String FileName)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 Rename(
            Object FileNode,
            Object FileDesc,
            String FileName,
            String NewFileName,
            Boolean ReplaceIfExists)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 GetSecurity(
            Object FileNode,
            Object FileDesc,
            ref Byte[] SecurityDescriptor)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 SetSecurity(
            Object FileNode,
            Object FileDesc,
            AccessControlSections Sections,
            Byte[] SecurityDescriptor)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 ReadDirectory(
            Object FileNode,
            Object FileDesc,
            String Pattern,
            String Marker,
            IntPtr Buffer,
            UInt32 Length,
            out UInt32 BytesTransferred)
        {
            return SeekableReadDirectory(FileNode, FileDesc, Pattern, Marker, Buffer, Length,
                out BytesTransferred);
        }
        public virtual Boolean ReadDirectoryEntry(
            Object FileNode,
            Object FileDesc,
            String Pattern,
            String Marker,
            ref Object Context,
            out String FileName,
            out FileInfo FileInfo)
        {
            FileName = default(String);
            FileInfo = default(FileInfo);
            return false;
        }
        public virtual Int32 ResolveReparsePoints(
            String FileName,
            UInt32 ReparsePointIndex,
            Boolean ResolveLastPathComponent,
            out IoStatusBlock IoStatus,
            IntPtr Buffer,
            ref UIntPtr Size)
        {
            GCHandle Handle = GCHandle.Alloc(this, GCHandleType.Normal);
            try
            {
                return Api.FspFileSystemResolveReparsePoints(
                    IntPtr.Zero,
                    GetReparsePointByName,
                    (IntPtr)Handle,
                    FileName,
                    ReparsePointIndex,
                    ResolveLastPathComponent,
                    out IoStatus,
                    Buffer,
                    ref Size);
            }
            finally
            {
                Handle.Free();
            }
        }
        public virtual Int32 GetReparsePointByName(
            String FileName,
            Boolean IsDirectory,
            IntPtr Buffer,
            ref UIntPtr Size)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 GetReparsePoint(
            Object FileNode,
            Object FileDesc,
            String FileName,
            IntPtr Buffer,
            out UIntPtr Size)
        {
            Size = default(UIntPtr);
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 SetReparsePoint(
            Object FileNode,
            Object FileDesc,
            String FileName,
            IntPtr Buffer,
            UIntPtr Size)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 DeleteReparsePoint(
            Object FileNode,
            Object FileDesc,
            String FileName,
            IntPtr Buffer,
            UIntPtr Size)
        {
            return STATUS_INVALID_DEVICE_REQUEST;
        }
        public virtual Int32 GetStreamInfo(
            Object FileNode,
            Object FileDesc,
            IntPtr Buffer,
            UInt32 Length,
            out UInt32 BytesTransferred)
        {
            BytesTransferred = default(UInt32);
            return STATUS_INVALID_DEVICE_REQUEST;
        }

        /* helpers */
        public static Int32 NtStatusFromWin32(UInt32 Error)
        {
            return Api.FspNtStatusFromWin32(Error);
        }
        public static UInt32 Win32FromNtStatus(Int32 Status)
        {
            return Api.FspWin32FromNtStatus(Status);
        }
        public Int32 SeekableReadDirectory(
            Object FileNode,
            Object FileDesc,
            String Pattern,
            String Marker,
            IntPtr Buffer,
            UInt32 Length,
            out UInt32 BytesTransferred)
        {
            Object Context = null;
            String FileName;
            DirInfo DirInfo = default(DirInfo);
            BytesTransferred = default(UInt32);
            while (ReadDirectoryEntry(FileNode, FileDesc, Pattern, Marker,
                ref Context, out FileName, out DirInfo.FileInfo))
            {
                DirInfo.SetFileNameBuf(FileName);
                if (!Api.FspFileSystemAddDirInfo(ref DirInfo, Buffer, Length,
                    out BytesTransferred))
                    break;
            }
            return STATUS_SUCCESS;
        }
        public Int32 BufferedReadDirectory(
            DirectoryBuffer DirectoryBuffer,
            Object FileNode,
            Object FileDesc,
            String Pattern,
            String Marker,
            IntPtr Buffer,
            UInt32 Length,
            out UInt32 BytesTransferred)
        {
            Object Context = null;
            String FileName;
            DirInfo DirInfo = default(DirInfo);
            Int32 DirBufferResult = STATUS_SUCCESS;
            BytesTransferred = default(UInt32);
            if (Api.FspFileSystemAcquireDirectoryBuffer(ref DirectoryBuffer.DirBuffer, null == Marker,
                out DirBufferResult))
                try
                {
                    while (ReadDirectoryEntry(FileNode, FileDesc, Pattern, Marker,
                        ref Context, out FileName, out DirInfo.FileInfo))
                    {
                        DirInfo.SetFileNameBuf(FileName);
                        if (!Api.FspFileSystemFillDirectoryBuffer(
                            ref DirectoryBuffer.DirBuffer, ref DirInfo, out DirBufferResult))
                            break;
                    }
                }
                finally
                {
                    Api.FspFileSystemReleaseDirectoryBuffer(ref DirectoryBuffer.DirBuffer);
                }
            if (0 > DirBufferResult)
            {
                BytesTransferred = default(UInt32);
                return DirBufferResult;
            }
            Api.FspFileSystemReadDirectoryBuffer(ref DirectoryBuffer.DirBuffer,
                Marker, Buffer, Length, out BytesTransferred);
            return STATUS_SUCCESS;
        }
        public Int32 FindReparsePoint(
            String FileName,
            out UInt32 ReparsePointIndex)
        {
            GCHandle Handle = GCHandle.Alloc(this, GCHandleType.Normal);
            try
            {
                return Api.FspFileSystemFindReparsePoint(
                    IntPtr.Zero,
                    GetReparsePointByName,
                    (IntPtr)Handle,
                    FileName,
                    out ReparsePointIndex);
            }
            finally
            {
                Handle.Free();
            }
        }
        private static Int32 GetReparsePointByName(
            IntPtr FileSystem,
            IntPtr Context,
            String FileName,
            Boolean IsDirectory,
            IntPtr Buffer,
            ref UIntPtr Size)
        {
            FileSystemBase self = (FileSystemBase)GCHandle.FromIntPtr(Context).Target;
            try
            {
                return self.GetReparsePointByName(
                    FileName,
                    IsDirectory,
                    Buffer,
                    ref Size);
            }
            catch (Exception ex)
            {
                return self.ExceptionHandler(ex);
            }
        }
    }

}
