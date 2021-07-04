--------------------------------------------------------
--  Fichier créé - dimanche-juillet-04-2021   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table AGENT
--------------------------------------------------------

  CREATE TABLE "ABDOU"."AGENT" 
   (	"MATRICULE" VARCHAR2(6 BYTE), 
	"NOM" VARCHAR2(30 BYTE), 
	"PRENOM" VARCHAR2(30 BYTE), 
	"NOM_JF" VARCHAR2(30 BYTE), 
	"DAT_NAI" DATE, 
	"LIEU_NAI" VARCHAR2(40 BYTE), 
	"NSS" VARCHAR2(20 BYTE), 
	"DAT_REC" DATE, 
	"SIT_FAM" VARCHAR2(1 BYTE), 
	"SIT_SN" VARCHAR2(1 BYTE), 
	"SEXE" VARCHAR2(1 BYTE), 
	"COD_STR" VARCHAR2(5 BYTE), 
	"DAT_SORT" DATE, 
	"CODE_AF" VARCHAR2(1 BYTE), 
	"NAT" VARCHAR2(10 BYTE), 
	"COD_FONC" VARCHAR2(6 BYTE), 
	"CAT" VARCHAR2(3 BYTE), 
	"ECH" VARCHAR2(2 BYTE), 
	"ADRESSE" VARCHAR2(80 BYTE), 
	"NCPT_BNC" VARCHAR2(20 BYTE), 
	"AR_NOM" VARCHAR2(40 BYTE), 
	"AR_PRENOM" VARCHAR2(40 BYTE), 
	"AR_NOM_JF" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
REM INSERTING into ABDOU.AGENT
SET DEFINE OFF;
