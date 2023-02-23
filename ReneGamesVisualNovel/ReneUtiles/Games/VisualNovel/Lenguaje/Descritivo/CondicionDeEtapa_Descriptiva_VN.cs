/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 16:07
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
using ReneUtiles.Games.VisualNovel.Progresos;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo
{
	/// <summary>
	/// Description of CondicionDeEtapa_Descriptiva_VN.
	/// </summary>
	public class CondicionDeEtapa_Descriptiva_VN:CondicionDeEtapa_VN
	{
		public Condicional Condicion; 
		public CondicionDeEtapa_Descriptiva_VN(Condicional condicion)
		{
			this.Condicion=condicion;
		}
	}
}
