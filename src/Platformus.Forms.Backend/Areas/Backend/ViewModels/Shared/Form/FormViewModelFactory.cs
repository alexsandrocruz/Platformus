﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Platformus.Barebone;
using Platformus.Forms.Data.Abstractions;
using Platformus.Forms.Data.Models;
using Platformus.Globalization.Backend.ViewModels;

namespace Platformus.Forms.Backend.ViewModels.Shared
{
  public class FormViewModelFactory : ViewModelFactoryBase
  {
    public FormViewModelFactory(IHandler handler)
      : base(handler)
    {
    }

    public FormViewModel Create(Form form)
    {
      return new FormViewModel()
      {
        Id = form.Id,
        Name = this.GetLocalizationValue(form.NameId),
        Fields = this.handler.Storage.GetRepository<IFieldRepository>().FilteredByFormId(form.Id).Select(
          f => new FieldViewModelFactory(this.handler).Create(f)
        )
      };
    }
  }
}