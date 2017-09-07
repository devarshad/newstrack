﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Models
{
    /// <summary>
    /// Holds the enums for Icon Position for Bootstrap control, user status, Message type and broadcast type.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Enum to represent story data type like uimages, audio and videos
        /// </summary>
        public enum StoryDataType : byte
        {
            /// <summary>
            /// Image type
            /// </summary>
            Image = 1,
            /// <summary>
            /// Audio type
            /// </summary>
            Audio,
            /// <summary>
            /// Video type
            /// </summary>
            Video
        }

        /// <summary>
        /// Enum to represent enum position(left/middle/right)
        /// </summary>
        public enum IconPosition : byte
        {
            /// <summary>
            /// Left
            /// </summary>
            LEFT = 1,
            /// <summary>
            /// Middle
            /// </summary>
            MIDDLE,
            /// <summary>
            /// Right
            /// </summary>
            RIGHT
        }

        /// <summary>
        /// Enum to hold user status
        /// </summary>
        public enum UserStatus : byte
        {
            /// <summary>
            /// Online
            /// </summary>        
            ONL = 1,
            /// <summary>
            /// Offline
            /// </summary>
            OFL,
            /// <summary>
            /// Busy
            /// </summary>
            BSY,
            /// <summary>
            /// DO not disturb
            /// </summary>
            DND
        }

        /// <summary>
        /// Defines the type of a alert/message.
        /// </summary>
        public enum MessageType : byte
        {
            /// <summary>
            /// Indicates error occured while in the execution in the program.
            /// In red color.
            /// </summary>
            Error,
            /// <summary>
            /// Indicates information is displayed to the user.
            /// In blue color.
            /// </summary>
            Information,
            /// <summary>
            /// Indicates a task completion success.
            /// In green color.
            /// </summary>
            Success,
            /// <summary>
            /// Indicates a system or program warning.
            /// In orange color.
            /// </summary>
            Warning
        }

        /// <summary>
        /// Define the type of Broadcasting messages to different clients
        /// </summary>
        public enum BroadCastType : byte
        {
            /// <summary>
            /// Web based client like SignalR
            /// </summary>
            Web = 1,

            /// <summary>
            /// App based client like mobile devices which supports notification services
            /// </summary>
            App
        }
    }
}
