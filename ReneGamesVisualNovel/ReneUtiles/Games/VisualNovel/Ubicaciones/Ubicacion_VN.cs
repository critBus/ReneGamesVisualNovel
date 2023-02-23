/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 14:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneUtiles.Games.VisualNovel.Visualizacion;
using ReneUtiles.Games.VisualNovel.Visualizacion.Dialogos;
namespace ReneUtiles.Games.VisualNovel.Ubicaciones
{
	/// <summary>
	/// Description of Ubicacion.
	/// </summary>
	public class Ubicacion_VN:Escenario_VN
	{
		public List<DisparadorDeDialogo_VN> listaDeDialogos;
		public Ubicacion_VN():base()
		{
		}
	}
}
