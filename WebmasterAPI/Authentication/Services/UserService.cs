using AutoMapper;
using WebmasterAPI.Authentication.Domain.Repositories;
using WebmasterAPI.Authentication.Domain.Services;
using WebmasterAPI.Authentication.Domain.Services.Communication;
using WebmasterAPI.Models;
using WebmasterAPI.Shared.Domain.Repositories;

namespace WebmasterAPI.Authentication.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    // public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model)
    // {
    //     
    // }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);

        if (user == null)
        {
            throw new ApplicationException("User not found");
        }
        return user;
    }

    public async Task RegisterAsync(RegisterRequest model)
    {
        if (_userRepository.ExistsByEmail(model.Email))
        {
            throw new ApplicationException($"Email '{model.Email}' is already taken");
        }

        var user = _mapper.Map<User>(model);

        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error ocurred while saving the user: {e.Message}");
        }
    }

    // public Task DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
}