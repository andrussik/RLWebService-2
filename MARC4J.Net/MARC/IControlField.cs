using System;

namespace MARC4J.Net.MARC
{
    public interface IControlField : IVariableField
    {
        String Data { get; set; }
    }
}