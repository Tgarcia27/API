using TriscalWebApi.Repository;
using TriscalWebApi.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomValidation
{
    internal class CustomValidationCPFAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}

// <summary>
/// Validação customizada para CPF
/// </summary>
public class CustomValidationCPFAttribute : ValidationAttribute, IClientValidatable
{
    /// <summary>
    /// </summary>
    public CustomValidationCPFAttribute() { }

    /// <summary>
    /// Validação server
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public override bool IsValid(object value)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
            return true;

        bool valido = Function.ValidaCPF(value.ToString());
        return valido;
    }

}