using AutoMapper;
using Core.Application.DTOs.UserProfile;
using Core.Application.Interface.Repositories;
using Core.Application.Interface.Services;
using Core.Application.Service;
using Core.Domain;
using System.Linq.Expressions;

namespace Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserService(IUserRepository userRepository, IMapper mapper, JwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }


        public async Task AddAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(user);
        }


        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }


        public async Task<IEnumerable<UserResponseDto>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            var users = await _userRepository.FindAsync(predicate);
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }


        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }


        public async Task<UserResponseDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }


        public async Task<AuthenticationResponse> GetDetailByEmailandPassword(LoginRequestDto requestDto)
        {

            var user = await _userRepository.GetDetailByEmailandPassword(requestDto.Email);
            if (user == null)
                return null;


            //if (!VerifyPassword(password, user.Password))
            //    return null;


            var authResponse = _mapper.Map<AuthenticationResponse>(user);

            authResponse.Token = _jwtService.GenerateToken(user);

            return authResponse;
        }


        public async Task Update(UpdateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.Update(user);
        }
    }
}
