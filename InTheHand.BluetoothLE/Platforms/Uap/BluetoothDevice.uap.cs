﻿//-----------------------------------------------------------------------
// <copyright file="BluetoothDevice.uap.cs" company="In The Hand Ltd">
//   Copyright (c) 2018-19 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using InTheHand.Bluetooth.GenericAttributeProfile;

namespace InTheHand.Bluetooth
{
    partial class BluetoothDevice
    {
        //static BluetoothLEAdvertisementWatcher _advertisementWatcher = new BluetoothLEAdvertisementWatcher();
        //static int _advertisementRefCount = 0;

        private readonly bool _watchingAdvertisements = false;
        internal BluetoothLEDevice NativeDevice;

        internal BluetoothDevice(BluetoothLEDevice device)
        {
            NativeDevice = device;
        }

        string GetId()
        {
            return NativeDevice.BluetoothAddress.ToString();
        }

        string GetName()
        {
            return NativeDevice.Name;
        }

        

        BluetoothRemoteGATTServer GetGatt()
        {
            return new BluetoothRemoteGATTServer(this);
        }

        /*bool GetWatchingAdvertisements()
        {
            return _watchingAdvertisements;
        }

        async Task DoWatchAdvertisements()
        {
            _watchingAdvertisements = true;
            _advertisementRefCount += 1;
            _advertisementWatcher.Received += _advertisementWatcher_Received;

            if(_advertisementWatcher.Status != BluetoothLEAdvertisementWatcherStatus.Started)
            {
                _advertisementWatcher.Start();
            }
        }

        private void _advertisementWatcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            if(args.BluetoothAddress == NativeDevice.BluetoothAddress)
            {
                OnAdvertismentReceived(new BluetoothAdvertisingEvent(this, (byte)args.RawSignalStrengthInDBm, args.Advertisement));
            }
        }

        void DoUnwatchAdvertisements()
        {
            _watchingAdvertisements = false;
            _advertisementRefCount -= 1;
            _advertisementWatcher.Received -= _advertisementWatcher_Received;

            if (_advertisementRefCount < 1 && _advertisementWatcher.Status != BluetoothLEAdvertisementWatcherStatus.Stopped)
            {
                _advertisementWatcher.Stop();
            }
        }*/
    }
}
