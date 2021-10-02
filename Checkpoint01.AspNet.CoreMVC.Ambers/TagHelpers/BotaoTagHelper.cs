using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint01.AspNet.CoreMVC.Ambers.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        //Propriedades são os atributos da tag
        public string Texto { get; set; }
        public string Class { get; set; }

        //<botao texto="" class=""></botao>
        //<input type="submit" value="Cadastrar" class="btn btn-success"/>

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag
            output.TagName = "input";
            //Definir os atributos type, value e class
            output.Attributes.SetAttribute("type", "submit");

            if (string.IsNullOrEmpty(Texto))
                output.Attributes.SetAttribute("value", "Cadastrar");
            else
                output.Attributes.SetAttribute("value", Texto);

            //Ternário..
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "btn btn-success" : Class);
        }
    }
}
