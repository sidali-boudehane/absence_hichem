--------------------------------------------------------
--  Fichier cr�� - dimanche-juillet-04-2021   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ABSENCE
--------------------------------------------------------

  CREATE TABLE "ABDOU"."ABSENCE" 
   (	"ID" NUMBER(*,0) GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE , 
	"MATRICULE" VARCHAR2(6 BYTE), 
	"TYPE" VARCHAR2(5 BYTE), 
	"DATE_ABSENCE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into ABDOU.ABSENCE
SET DEFINE OFF;
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('68','00014N','AA',to_date('05/02/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('69','00014N','AA',to_date('17/02/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('70','00014N','AO',to_date('11/03/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('71','00014N','O',to_date('09/05/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('72','00014N','A',to_date('10/05/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('73','00014N','O',to_date('09/06/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('93','00559K','AO',to_date('03/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('94','00559K','AO',to_date('04/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('95','00559K','AO',to_date('05/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('76','00007Q','AO',to_date('03/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('47','00018W','AA',to_date('08/06/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('96','00559K','AO',to_date('06/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('77','00007Q','AO',to_date('04/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('97','00559K','AO',to_date('07/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('98','00559K','AO',to_date('08/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('99','00559K','AO',to_date('09/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('100','00559K','AO',to_date('10/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('91','00559K','AO',to_date('01/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('92','00559K','AO',to_date('02/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('1','00256c','AO',to_date('30/06/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('74','00007Q','AO',to_date('01/07/21','DD/MM/RR'));
Insert into ABDOU.ABSENCE (ID,MATRICULE,TYPE,DATE_ABSENCE) values ('75','00007Q','AO',to_date('02/07/21','DD/MM/RR'));
--------------------------------------------------------
--  DDL for Index ABSENCE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ABDOU"."ABSENCE_PK" ON "ABDOU"."ABSENCE" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table ABSENCE
--------------------------------------------------------

  ALTER TABLE "ABDOU"."ABSENCE" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "ABDOU"."ABSENCE" ADD CONSTRAINT "ABSENCE_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;