using System;
using CookMate.Models;
using CookMate.Controllers;
using CookMate.shared;

namespace CookMate.Models {

    public class ErrorViewModel {

        public string RequestId {
            get;
            set;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}