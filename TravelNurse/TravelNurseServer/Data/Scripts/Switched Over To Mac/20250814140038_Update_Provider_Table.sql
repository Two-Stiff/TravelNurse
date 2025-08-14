START TRANSACTION;

ALTER TABLE "Providers" DROP CONSTRAINT "FK_Providers_States_TemporaryStateId";

ALTER TABLE "Providers" DROP COLUMN "ForceNextLogout";

ALTER TABLE "Providers" DROP COLUMN "LastRecruiterId";

ALTER TABLE "Providers" DROP COLUMN "ReferralDate";

ALTER TABLE "Providers" DROP COLUMN "ReferredBy";

ALTER TABLE "Providers" DROP COLUMN "SensitiveDataModifiedOn";

ALTER TABLE "Providers" DROP COLUMN "TemporaryCity";

ALTER TABLE "Providers" DROP COLUMN "TemporaryStreetAddress";

ALTER TABLE "Providers" DROP COLUMN "TemporaryZipCode";

ALTER TABLE "Providers" RENAME COLUMN "TravelerId" TO "Status";

ALTER TABLE "Providers" RENAME COLUMN "TemporaryStateId" TO "SpecialtyId";

ALTER INDEX "IX_Providers_TemporaryStateId" RENAME TO "IX_Providers_SpecialtyId";

ALTER TABLE "Providers" ADD CONSTRAINT "FK_Providers_Specialties_SpecialtyId" FOREIGN KEY ("SpecialtyId") REFERENCES "Specialties" ("Id");

COMMIT;

