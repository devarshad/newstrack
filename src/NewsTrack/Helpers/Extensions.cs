﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsTrack.Helpers
{
    public static class ModelStateExtensions
    {
        public static String JsonValidation(this System.Web.Http.ModelBinding.ModelStateDictionary state)
        {
            return JsonConvert.SerializeObject(
                state.Where(x => x.Value.Errors.Count > 0)
                .Select(e => new
                {
                    Name = e.Key,
                    Errors = e.Value.Errors.Select(x => x.ErrorMessage)
                       .Concat(e.Value.Errors.Where(x => x.Exception != null).Select(x => x.Exception.Message))
                })
                );
        }
    }
}