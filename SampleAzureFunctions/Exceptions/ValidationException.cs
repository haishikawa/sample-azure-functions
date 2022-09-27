using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Exceptions
{
    public class ValidationException:Exception
    {
        public List<ValidationResult> validationResults;
    }
}
