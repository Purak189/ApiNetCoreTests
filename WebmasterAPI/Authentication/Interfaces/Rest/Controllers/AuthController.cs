using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebmasterAPI.Authentication.Domain.Services;
using WebmasterAPI.Authentication.Domain.Services.Communication;
using WebmasterAPI.Authentication.Resources;
using WebmasterAPI.Data;
using WebmasterAPI.Models;

namespace WebmasterAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]

public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public AuthController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    
    // [HttpPost("sign-in")]
    // public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    // {
    //     var response = await _userService.A
    //
    //     return Ok(user);
    // }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        return Ok(resources);
    }

}