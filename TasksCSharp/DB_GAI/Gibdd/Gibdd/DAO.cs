using Gibdd.DBO;
using Gibdd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gibdd
{
    class DAO
    {

        public DAO()
        {}

        public List<OwnerForSearch> GetResultOfSearchEntities(string word, string way)
        {
            List<OwnerForSearch> ResultOwners = null;

            switch (way)
            {
                case "ФИО владельца":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.Chef.Contains(word)).ToList();
                    }
                    break;
                case "Номер телефона":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.Phone.Contains(word)).ToList();
                    }
                    break;
                case "Местонахождение":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.Address.Contains(word)).ToList();
                    }
                    break;
                case "Район":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.District.Contains(word)).ToList();
                    }
                    break;
                case "Организация":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.NameCompany.Contains(word)).ToList();
                    }
                    break;
                case "ИНН":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.Entities.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.EntityID,
                            NameCompany = o.EntityName,
                            Chef = o.Chief,
                            Phone = o.Owners.Phone,
                            Inn = o.EntityInn,
                            Address = o.Owners.Address,
                            District = o.Owners.District
                        }).Where(o => o.Inn.Contains(word)).ToList();
                    }
                    break;
            }
            return ResultOwners;
        }
        public List<OwnerForSearch> GetResultOfSearchIndvidual(string word, string way)
        {
            List<OwnerForSearch> ResultOwners = null;

            switch (way)
            {
                case "ФИО владельца":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.IndividualOwners.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.IndividualOwnerID,
                            Fio = o.OwnerFio,
                            Phone = o.Owners.Phone,
                            Address = o.Owners.Address,
                            District = o.Owners.District,

                        }).Where(o => o.Fio.Contains(word)).ToList();
                    }
                    break;
                case "Номер телефона":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.IndividualOwners.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.IndividualOwnerID,
                            Fio = o.OwnerFio,
                            Phone = o.Owners.Phone,
                            Address = o.Owners.Address,
                            District = o.Owners.District,

                        }).Where(o => o.Phone.Contains(word)).ToList();
                    }
                    break;
                case "Местонахождение":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.IndividualOwners.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.IndividualOwnerID,
                            Fio = o.OwnerFio,
                            Phone = o.Owners.Phone,
                            Address = o.Owners.Address,
                            District = o.Owners.District,

                        }).Where(o => o.Address.Contains(word)).ToList();
                    }
                    break;
                case "Район":
                    using (DBContext db = new DBContext())
                    {
                        ResultOwners = db.IndividualOwners.Select(o => new OwnerForSearch
                        {
                            IndOwnerID = o.IndividualOwnerID,
                            Fio = o.OwnerFio,
                            Phone = o.Owners.Phone,
                            Address = o.Owners.Address,
                            District = o.Owners.District,

                        }).Where(o => o.District.Contains(word)).ToList();
                    }
                    break;
            }
            return ResultOwners;
        }
        public List<AutoForSearch> GetResultOfSearchAutos(string word, string way)
        {
            List<AutoForSearch> ResultAutos = null;
            switch (way)
            {
                case "Гос. номер":
                    using(DBContext db = new DBContext())
                    {
                        ResultAutos = db.Autos.Select(o => new AutoForSearch
                        {
                            AutoID = o.AutoID,
                            Number = o.Number,
                            Brand = o.Brand,
                            Model = o.Model,
                            EngineNumber = o.EngineID,
                            BodyNumber = o.BodyID,
                            Year = o.Year,
                            DrivingAway = o.DrivingAway,
                        }).Where(o=>o.Number == word).ToList();
                    }
                    break;
                case "Бренд":
                    using (DBContext db = new DBContext())
                    {
                        ResultAutos = db.Autos.Select(o => new AutoForSearch
                        {
                            AutoID = o.AutoID,
                            Number = o.Number,
                            Brand = o.Brand,
                            Model = o.Model,
                            EngineNumber = o.EngineID,
                            BodyNumber = o.BodyID,
                            Year = o.Year,
                            DrivingAway = o.DrivingAway,
                        }).Where(o => o.Brand.Contains(word)).ToList();
                    }
                    break;
                case "Модель":
                    using (DBContext db = new DBContext())
                    {
                        ResultAutos = db.Autos.Select(o => new AutoForSearch
                        {
                            AutoID = o.AutoID,
                            Number = o.Number,
                            Brand = o.Brand,
                            Model = o.Model,
                            EngineNumber = o.EngineID,
                            BodyNumber = o.BodyID,
                            Year = o.Year,
                           
                            DrivingAway = o.DrivingAway,
                        }).Where(o => o.Model.Contains(word)).ToList();
                    }
                    break;
                case "№ двигателя":
                    using (DBContext db = new DBContext())
                    {
                        ResultAutos = db.Autos.Select(o => new AutoForSearch
                        {
                            AutoID = o.AutoID,
                            Number = o.Number,
                            Brand = o.Brand,
                            Model = o.Model,
                            EngineNumber = o.EngineID,
                            BodyNumber = o.BodyID,
                            Year = o.Year,
                           
                            DrivingAway = o.DrivingAway,
                        }).Where(o => o.EngineNumber == word).ToList();
                    }
                    break;
                case "№ кузова":
                    using (DBContext db = new DBContext())
                    {
                        ResultAutos = db.Autos.Select(o => new AutoForSearch
                        {
                            AutoID = o.AutoID,
                            Number = o.Number,
                            Brand = o.Brand,
                            Model = o.Model,
                            EngineNumber = o.EngineID,
                            BodyNumber = o.BodyID,
                            Year = o.Year,
                           
                            DrivingAway = o.DrivingAway,
                        }).Where(o => o.BodyNumber == word).ToList();
                    }
                    break;
            }
            return ResultAutos;
        }
        public OwnerFullInfo GetFullInformationIndividualOwner(int id, bool isEntity)
        {
            List<OwnerFullInfo> ownerFullInfo = new List<OwnerFullInfo>();
            List<AutoForCardIndOwner> autoForSearch = new List<AutoForCardIndOwner>();
            using (DBContext db = new DBContext())
            {
                if(isEntity == true)
                {
                    ownerFullInfo = db.Owners.Include("Entities").Select(o => new OwnerFullInfo
                    {
                        IndOwnerID = o.OwnerID,
                        Fio = o.Entities.Chief,
                        Phone = o.Phone,
                        Address = o.Address,
                        District = o.District,
                        IsEntity = true,
                        NameCompany = o.Entities.EntityName,
                        Inn = o.Entities.EntityInn
                    }).Where(o => o.IndOwnerID == id).ToList();
                }
                else
                {
                    ownerFullInfo = db.Owners.Include("IndividualOwners").Select(o => new OwnerFullInfo
                    {
                        IndOwnerID = o.OwnerID,
                        Fio = o.IndividualOwners.OwnerFio,
                        Phone = o.Phone,
                        Address = o.Address,
                        IsEntity = false,
                        District = o.District,
                    }).Where(o => o.IndOwnerID == id).ToList();
                }
                autoForSearch = db.Autos.Select(p => new AutoForCardIndOwner
                {
                    AutoID = p.AutoID,
                    Number = p.Number,
                    Brand = p.Brand,
                    Model = p.Model,
                    Year = p.Year,
                    DrivingAway = p.DrivingAway,
                    OwnerID = p.OwnerID,
                }).Where(p => p.OwnerID == id).ToList();   
            }
            ownerFullInfo[0].Autos = autoForSearch;
            return ownerFullInfo[0];
        }
        public Autos GetFullInfoAboutAuto(int autoIDin)
        {
            List<Autos> autosResult;
            List<TechnicalInspections> technicalResult;
            List<Stealings> stealingsResult;

            using(DBContext db = new DBContext())
            {
                stealingsResult = db.Stealings.AsEnumerable().Select(o => new Stealings
                {
                    StealingID = o.StealingID,
                    AutoID = o.AutoID,
                    DateAway = o.DateAway,
                    DateReturn = o.DateReturn
                }).Where(o => o.AutoID == autoIDin).ToList();
            }

            using(DBContext db = new DBContext())
            {
                technicalResult = db.TechnicalInspections.AsEnumerable().Select(o => new TechnicalInspections
                    {
                        AutoID = o.AutoID,
                        Inspector = o.Inspector,
                        DateSee = o.DateSee,
                        Distance = o.Distance,
                        Reason = o.Reason,
                        Okey = o.Okey,
                        Work = o.Work,
                        YearNumber = o.YearNumber
                        
                    }).Where(o => o.AutoID == autoIDin).ToList();
            }

            using (DBContext db = new DBContext())
            {
                autosResult = db.Autos.AsEnumerable().Select(o => new Autos
                {
                    AutoID = o.AutoID,
                    Number = o.Number,
                    Brand = o.Brand,
                    Model = o.Model,
                    BodyID = o.BodyID,
                    EngineID = o.EngineID,
                    BodyModel = o.BodyModel,
                    Color = o.Color,
                    Drive = o.Drive,
                    DrivingAway = o.DrivingAway,
                    Helm = o.Helm,
                    TypeBody = o.TypeBody,
                    Power = o.Power,
                    Volume = o.Volume,
                    Year = o.Year,
                    YearTax = o.YearTax,
                    Comment = o.Comment,
                    OwnerID = o.OwnerID

                }).Where(o => o.AutoID == autoIDin).ToList();
            }
            autosResult[0].Stealings = stealingsResult;
            autosResult[0].TechnicalInspections = technicalResult;
            return autosResult[0];
        }
        public void ChangeOwner(int id, bool isEntity, Owners owners, Entities entities,
            IndividualOwners individualOwners)
        {
            if (isEntity)
            {
                using(DBContext db = new DBContext())
                {
                    Owners owner = db.Owners.Where(o => o.OwnerID == id).FirstOrDefault();
                    Entities entity = db.Entities.Where(o => o.EntityID == id).FirstOrDefault();

                    owner.Address = owners.Address;
                    owner.District = owners.District;
                    owner.Phone = owners.Phone;

                    entity.Chief = entities.Chief;
                    entity.EntityName = entities.EntityName;
                    entity.EntityInn = entities.EntityInn;
                    db.SaveChanges();
                }
            }
            else
            {
                using (DBContext db = new DBContext())
                {
                    Owners owner = db.Owners
                        .Where(o => o.OwnerID == id)
                        .FirstOrDefault();
                    IndividualOwners individualOwner = db.IndividualOwners
                        .Where(o => o.IndividualOwnerID == id).FirstOrDefault();
                    owner.Address = owners.Address;
                    owner.District = owners.District;
                    owner.Phone = owners.Address;
                    individualOwner.OwnerFio = individualOwners.OwnerFio;
                    db.SaveChanges();
                }


            }
        }
        public void ChangeAuto(Autos auto)
        {
            using(DBContext db = new DBContext())
            {
                Autos autos = db.Autos.Where(o => o.AutoID == auto.AutoID).FirstOrDefault();
                autos.BodyID = auto.BodyID;
                autos.BodyModel = auto.BodyModel;
                autos.Brand = auto.Brand;
                autos.Model = auto.Model;
                autos.Number = auto.Number;
                autos.Power = auto.Power;
                autos.Volume = auto.Volume;
                autos.YearTax = auto.YearTax;
                autos.Color = auto.Color;
                autos.Drive = auto.Drive;
                autos.Comment = auto.Comment;
                db.SaveChanges();
            }
        }

        public void AddAuto(Autos newAuto)
        {
            using(DBContext db = new DBContext())
            {
                db.Autos.Add(newAuto);
                db.SaveChanges();
            }
        }
        public void AddIndvidualOwner(Owners owners, IndividualOwners individualOwners)
        {
            using (DBContext db = new DBContext())
            {
                db.Owners.Add(owners);
                individualOwners.Owners = owners;
                db.IndividualOwners.Add(individualOwners);
                db.SaveChanges();
            }
        }
        public void AddEntity(Owners owners, Entities entities)
        {
            using (DBContext db = new DBContext())
            {
                db.Owners.Add(owners);
                entities.Owners = owners;
                db.Entities.Add(entities);
                db.SaveChanges();
            }
        }

        public void AddTechnical(TechnicalInspections tech)
        {
            using(DBContext db = new DBContext())
            {
                db.TechnicalInspections.Add(new TechnicalInspections
                {
                    AutoID = tech.AutoID,
                    DateSee = tech.DateSee,
                    Distance = tech.Distance,
                    Inspector = tech.Inspector,
                    Okey = tech.Okey,
                    Reason = tech.Reason,
                    Work = tech.Work,
                    YearNumber = tech.YearNumber
                });
                db.SaveChanges();
            }
        }

        public void AddStealing(Stealings stealing)
        {
            using (DBContext db = new DBContext())
            {
                db.Stealings.Add(stealing);
                db.SaveChanges();

            }
        }
        

        public void DeleteAuto(int id)
        {
            using (DBContext db = new DBContext())
            {
                Autos autos = db.Autos.Where(o => o.AutoID == id).FirstOrDefault();
                db.Autos.Remove(autos);
            }
        }
        public void DeleteIndvidualOwner(int id)
        {
            using (DBContext db = new DBContext())
            {
                Owners owner = db.Owners.Where(o => o.OwnerID == id).FirstOrDefault();
                db.Owners.Remove(owner);
            }
        }
        public void DeleteEntity(int id)
        {
            using (DBContext db = new DBContext())
            {
                Owners owner = db.Owners.Where(o => o.OwnerID == id).FirstOrDefault();
                db.Owners.Remove(owner);
            }
        }


    }
}
                