using DataView2.Core.Models;
using MAUIBlazorCFService.Interfaces;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using ProtoBuf.Grpc;

namespace MAUIBlazorCFService.Services
{
    public class PersonaService : ISettingsService
    {
        private readonly IRepository<Persona> _repository;
        public PersonaService(IRepository<Persona> repository)
        {
            _repository = repository;
        }

        public async Task<IdReply> Create(Persona request, CallContext context = default)
        {
            try
            {
                var entity = await _repository.CreateAsync(request);
                return new IdReply
                {
                    Id = entity.IdPersona,
                    Message = "Setting Created Successfully."
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<Persona>> GetAll(Empty empty, CallContext context = default)
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                List<Persona> lists = new List<Persona>();
                foreach (var entity in entities)
                {
                    lists.Add(entity);
                }

                return lists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Persona> EditValue(Persona request, CallContext context = default)
        {
            try
            {
                var entityUpdated = await _repository.UpdateAsync(request);
                return entityUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Persona> AddValue(Persona request, CallContext context = default)
        {
            try
            {
                var entityUpdated = await _repository.CreateAsync(request);
                return entityUpdated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DelValue(string request, CallContext context = default)
        {
            try
            {
                await _repository.DeleteAsync(request);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
    }
}
