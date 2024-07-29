; r.asm
; werewolf nations' first pass at this shti

.686
.model flat, stdcall
option casemap:none

include \masm32\include\windows.inc
include \masm32\include\kernel32.inc
include \masm32\include\user32.inc

includelib \masm32\lib\kernel32.lib
includelib \masm32\lib\user32.lib

.data
; Data section can be defined here

.code
  NtAllocateVirtualMemory PROC
    mov r10, rcx
    mov eax, 0018h
    syscall
    ret
  NtAllocateVirtualMemory ENDP

END NtAllocateVirtualMemory

    