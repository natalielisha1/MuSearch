﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuSearch.DB.Interfaces
{
    interface IModel
    {
        /// <summary>
        /// The Function is processing the incoming messages from the server
        /// </summary>
        /// <param name="sender">The source of the message</param>
        /// <param name="e">The CommandMessageEventArgs arguments that were
        ///                 send along the message</param>
        //void ProcessMessage(object sender, CommandMessageEventArgs e);
        /// <summary>
        /// The Function is responsible of sending requests to the server
        /// </summary>
        /// <param name="command">The type of message, by command</param>
        /// <param name="args">Arguments related to the command</param>
        //void SendMessage(CommandEnum command, string[] args);
    }
}
