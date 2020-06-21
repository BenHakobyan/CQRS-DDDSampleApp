using SampleApp.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Application.Contact.EditContact
{
    public class EditContactCommand : ICommand
    {
        public ContactDTO Contact { get; set; }
    }
}
