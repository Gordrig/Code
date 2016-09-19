using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

using Sandbox.Common;
using Sandbox.Definitions;
using Sandbox.Engine;
using Sandbox.Game;
using Sandbox.Game.Components;

using Sandbox.ModAPI;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;

namespace ClassLibrary1
{
    //public struct AssemblerAndProgress {public int AssemblerID; public float PreviousProgress; public float CurrentProgress;}

    public static class AssemblerModifier 
    {
        public static void Init()
        {
            MethodInfo MI = typeof(AssemblerModifier).GetMethod("UpdateCurrentItemStatus");
            MethodBody MB = MI.GetMethodBody();
            byte[] MethodBytes = MB.GetILAsByteArray();
            int methodSize = MethodBytes.Length;


            GCHandle hmem = GCHandle.Alloc((object) MethodBytes, GCHandleType.Pinned);
            IntPtr addr = hmem.AddrOfPinnedObject();

            MethodRental.SwapMethodBody(typeof(MyCraftingComponentBase), MI.MetadataToken, addr, methodSize, MethodRental.JitImmediate);
        }

        public virtual void UpdateCurrentItemStatus(float statusDelta)
        {
            if (!IsProducing)
                return;

            var itemInProduction = GetItemToProduce(m_currentItem);
            if (itemInProduction == null)
            {
                return;
            }
            var blueprint = itemInProduction.Blueprint;

            m_currentItemStatus = Math.Min(1.0f, m_currentItemStatus + (m_elapsedTimeMs * m_craftingSpeedMultiplier) / (blueprint.BaseProductionTimeInSeconds * 1000f));
        }
    }
}
