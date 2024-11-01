using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportStore.API.Interfaces;
using SportStore.API.Entities;
namespace SportStore.API.Controllers
{
    
[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleRepository _repo;
    public RolesController(IRoleRepository repo)
    {
       _repo = repo;
    }

    [HttpPost]
    public ActionResult CreateRole(Role Role){

        return CreatedAtAction(nameof(GetRoleById), new { id = Role.Id }, Role);
    }
    
    [HttpGet]
    public ActionResult GetRole(){
        return Ok(_repo.GetRoles());
    }
    

    [HttpPut]
    public ActionResult UpdateRole(Role Role){
       return Ok(_repo.EditRole(Role, Role.Id));
    }


    [HttpGet("{id}")]
    public ActionResult GetRoleById(Guid id){
       return Ok(_repo.FindRoleById(id));
    }


    [HttpDelete]
    public ActionResult DeleteRole(Guid id){
        return Ok(_repo.DeleteRole(id));
    }

}
}