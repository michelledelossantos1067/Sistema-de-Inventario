using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Categoria;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;

public class CategoriaServices : ICategoriaServices{
    private readonly ICategoriaRepositories _categoriaRepositories;

    public CategoriaServices(ICategoriaRepositories categoriaRepositories){
        _categoriaRepositories = categoriaRepositories;
    }

    public async Task<List<CategoriaResponseDTOs>> ObtenerTodos(){
        
        var categorias = await _categoriaRepositories.ObtenerTodos();
        return categorias.Select(c => new CategoriaResponseDTOs{
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,

        }).ToList();
    }
    public async Task<CategoriaResponseDTOs?> ObtenerPorId(int Id){
        var categoria = await _categoriaRepositories.ObtenerPorId(Id);
        if(categoria == null){
            return null;
        };
        var categoriaDTO = new CategoriaResponseDTOs{
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
        return categoriaDTO;
    }
    public async Task Crear(CreateCategoriaDTOs createCategoriaDTOs){
        var categoria = new Categoria{
            Nombre = createCategoriaDTOs.Nombre,
            Descripcion = createCategoriaDTOs.Descripcion
        };
        await _categoriaRepositories.Crear(categoria);
    }
    public async Task Actualizar(int Id,UpdateCategoriaDTOs updateCategoriaDTOs){
        var categorias = await _categoriaRepositories.ObtenerPorId(Id);
        if(categorias == null){
            throw new Exception("No existe esta categoria.");
        };
        categorias.Nombre = updateCategoriaDTOs.Nombre;
        categorias.Descripcion = updateCategoriaDTOs.Descripcion;
        await _categoriaRepositories.Actualizar(Id,categorias);
    }
    public async Task Eliminar(int Id){
        var categoria = await _categoriaRepositories.ObtenerPorId(Id);
        if(categoria == null){
            throw new Exception("No existe esta categoria.");
        };
        await _categoriaRepositories.Eliminar(Id);
    }
}