﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace EasyToFind.Models
{
    public class Guardar
    {
        public string Email { get; set; }
        public string Texto { get; set; }
    }
}
