
using PDA.Models;
using System.Data.OracleClient;

namespace PDA.Services
{
    public class ContainerService
    {
        public interface IContainerService
        {
           // Task SaveContainerAsync(Models.ContainerInformation containerDto);
        }

        //public class ContainerService : IContainerService
        //{
        //    private readonly string _connectionString;

        //    public ContainerService(IConfiguration configuration)
        //    {
        //        _connectionString = configuration.GetConnectionString("DefaultConnection");
        //    }

        //    public async Task SaveContainerAsync(ContainerDto containerDto)
        //    {
        //        using (var connection = new OracleConnection(_connectionString))
        //        {
        //            await connection.OpenAsync();
        //            using (var transaction = connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    // Insert data into VesselVoyage table
        //                  //  var voyageId = await connection.ExecuteScalarAsync<int>(
        //                  //      @"INSERT INTO VesselVoyage (VesselName, Date, RotationNumber, CreatedAt)
        //                  //VALUES (:VesselName, :Date, :RotationNumber, SYSDATE)
        //                  //RETURNING VoyageId INTO :VoyageId",
        //                  //      new
        //                  //      {
        //                  //          VesselName = containerDto.VesselName,
        //                  //          Date = containerDto.Date,
        //                  //          RotationNumber = containerDto.RotationNumber,
        //                  //          VoyageId = 0 // Output parameter
        //                  //      });

        //                  //  // Insert data into ContainerInformation table
        //                  //  var cycleId = await connection.ExecuteScalarAsync<int>(
        //                  //      @"INSERT INTO ContainerInformation (ContainerNumber, VoyageId, Date, Size, Type, MadeOf, ContainerImage, CreatedAt)
        //                  //VALUES (:ContainerNumber, :VoyageId, :Date, :Size, :Type, :MadeOf, :ContainerImage, SYSDATE)
        //                  //RETURNING CycleId INTO :CycleId",
        //                  //      new
        //                  //      {
        //                  //          ContainerNumber = containerDto.ContainerNo,
        //                  //          VoyageId = voyageId,
        //                  //          Date = containerDto.Date,
        //                  //          Size = containerDto.Size,
        //                  //          Type = containerDto.Type,
        //                  //          MadeOf = containerDto.MadeOf,
        //                  //          ContainerImage = containerDto.ContainerImage,
        //                  //          CycleId = 0 // Output parameter
        //                  //      });

        //                  //  // Insert damage records into DamagedContainer table
        //                  //  foreach (var damageId in containerDto.DamageIds)
        //                  //  {
        //                  //      await connection.ExecuteAsync(
        //                  //          @"INSERT INTO DamagedContainer (ContainerId, DamageId, EmployeeId, Comments, CreatedAt)
        //                  //    VALUES (:ContainerId, :DamageId, :EmployeeId, :Comments, SYSDATE)",
        //                  //          new
        //                  //          {
        //                  //              ContainerId = cycleId,
        //                  //              DamageId = damageId,
        //                  //              EmployeeId = containerDto.EmployeeId,
        //                  //              Comments = containerDto.Remarks
        //                  //          });
        //                  //  }

        //                    transaction.Commit();
        //                }
        //                catch (Exception)
        //                {
        //                    transaction.Rollback();
        //                    throw;
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
