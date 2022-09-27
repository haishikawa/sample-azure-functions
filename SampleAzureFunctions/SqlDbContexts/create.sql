-- プロジェクトには含めないこと
DROP TABLE IF EXISTS [t_yuso]
GO

CREATE TABLE [dbo].[t_yuso] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [status] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [current_yuso_no] [int] NULL ,
    [has_chukei] [int] DEFAULT 0 NULL ,
    [sagyo_type] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [hikitori_date_from] [datetime2] NULL ,
    [hikitori_date_to] [datetime2] NULL ,
    [hikitorisaki_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_bukaei_name] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_prefecture] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_address] [varchar] (160) COLLATE Japanese_CI_AS NULL ,
    [hikitori_kojintaku_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [nosha_date_from] [datetime2] NULL ,
    [nosha_date_to] [datetime2] NULL ,
    [noshasaki_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_bukaei_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_prefecture] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_address] [varchar] (160) COLLATE Japanese_CI_AS NULL ,
    [nosha_kojintaku_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [seikyu_nikubun_mei] [varchar] (2) COLLATE Japanese_CI_AS NULL ,
    [meigi_henko_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [car_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [chassis_no] [char] (13) COLLATE Japanese_CI_AS NULL ,
    [car_type] [varchar] (3) COLLATE Japanese_CI_AS NULL ,
    [toroku_no] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [color] [varchar] (5) COLLATE Japanese_CI_AS NULL ,
    [mycar_user] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [mileage] [decimal] NULL ,
    [has_shakensho] [int] DEFAULT 0 NULL ,
    [has_jibaiseki] [int] DEFAULT 0 NULL ,
    [has_kanban] [int] DEFAULT 0 NULL ,
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [hikitori_tenkaizu_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [saishin_tenkaizu_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_yuso] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_yuso] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_yuso_detail]
GO

CREATE TABLE [dbo].[t_yuso_detail] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [yuso_no] [int] NOT NULL ,
    [status] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [yuso_tantosha_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [yuso_start_date] [datetime2] NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_yuso_detail] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_yuso_detail] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [yuso_no] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_yuso_rireki]
GO

CREATE TABLE [dbo].[t_yuso_rireki] (
    [rireki_id] [int] IDENTITY (1, 1) NOT NULL ,
    [rireki_toroku_date] [datetime2] NULL ,
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [status] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [current_yuso_no] [int] NULL ,
    [has_chukei] [int] DEFAULT 0 NULL ,
    [sagyo_type] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [hikitori_date_from] [datetime2] NULL ,
    [hikitori_date_to] [datetime2] NULL ,
    [hikitorisaki_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_bukaei_name] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_prefecture] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [hikitorisaki_address] [varchar] (160) COLLATE Japanese_CI_AS NULL ,
    [hikitori_kojintaku_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [nosha_date_from] [datetime2] NULL ,
    [nosha_date_to] [datetime2] NULL ,
    [noshasaki_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_bukaei_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_prefecture] [varchar] (10) COLLATE Japanese_CI_AS NULL ,
    [noshasaki_address] [varchar] (160) COLLATE Japanese_CI_AS NULL ,
    [nosha_kojintaku_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [seikyu_nikubun_mei] [varchar] (2) COLLATE Japanese_CI_AS NULL ,
    [meigi_henko_type] [varchar] (1) COLLATE Japanese_CI_AS NULL ,
    [car_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [chassis_no] [char] (13) COLLATE Japanese_CI_AS NULL ,
    [car_type] [varchar] (3) COLLATE Japanese_CI_AS NULL ,
    [toroku_no] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [color] [varchar] (5) COLLATE Japanese_CI_AS NULL ,
    [mycar_user] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [mileage] [decimal] NULL ,
    [has_shakensho] [int] DEFAULT 0 NULL ,
    [has_jibaiseki] [int] DEFAULT 0 NULL ,
    [has_kanban] [int] DEFAULT 0 NULL ,
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NULL ,
    [hikitori_tenkaizu_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [saishin_tenkaizu_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_yuso_rireki] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_yuso_rireki] PRIMARY KEY  CLUSTERED 
    (
        [rireki_id] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_gazo]
GO

CREATE TABLE [dbo].[t_gazo] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_category] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_type] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] default 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_gazo] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_gazo] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [gazo_category] ,
        [gazo_type] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_gazo]
GO

CREATE TABLE [dbo].[m_gazo] (
    [gazo_category] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_type] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_category_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [gazo_type_name] [varchar] (60) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_gazo] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_gazo] PRIMARY KEY  CLUSTERED 
    (
        [gazo_category] ,
        [gazo_type] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_kizu_gazo]
GO

CREATE TABLE [dbo].[t_kizu_gazo] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [parts_no] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_no] [int] NOT NULL ,
    [original_gazo_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [edit_gazo_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [yuso_no] [int] NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_kizu_gazo] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_kizu_gazo] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [tenkaizu_type] ,
        [parts_no] ,
        [gazo_no] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_kizu]
GO

CREATE TABLE [dbo].[t_kizu] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [parts_no] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [kizu_code] [varchar] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [yuso_no] [int] NULL ,
    [x_zahyo] [decimal] NULL ,
    [y_zahyo] [decimal] NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_kizu] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_kizu] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [tenkaizu_type] ,
        [parts_no] ,
        [kizu_code] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_tenkaizu]
GO

CREATE TABLE [dbo].[t_tenkaizu] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [yuso_no] [int] NOT NULL ,
    [tenkaizu_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_tenkaizu] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_tenkaizu] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [yuso_no] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_customer_sign]
GO

CREATE TABLE [dbo].[t_customer_sign] (
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [sign_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [sign_date] [datetime2] NULL ,
    [has_kyodaku_1] [int] DEFAULT 0 NULL ,
    [has_kyodaku_2] [int] DEFAULT 0 NULL ,
    [sign_gazo_file_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_customer_sign] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_customer_sign] PRIMARY KEY  CLUSTERED 
    (
        [juchu_no] ,
        [sign_type] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_parts]
GO

CREATE TABLE [dbo].[m_parts] (
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [parts_no] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [tenkaizu_type_name] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [parts_name] [varchar] (60) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_parts] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_parts] PRIMARY KEY  CLUSTERED 
    (
        [tenkaizu_type] ,
        [parts_no] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_parts_kizu]
GO

CREATE TABLE [dbo].[m_parts_kizu] (
    [tenkaizu_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [parts_no] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [kyoyo_kizu_code] [varchar] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_parts_kizu] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_parts_kizu] PRIMARY KEY  CLUSTERED 
    (
        [tenkaizu_type] ,
        [parts_no] ,
        [kyoyo_kizu_code] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_login_log]
GO

CREATE TABLE [dbo].[t_login_log] (
    [id] [int] IDENTITY (1, 1) NOT NULL ,
    [login_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_login_log] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_login_log] PRIMARY KEY  CLUSTERED 
    (
        [id] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [t_event_log]
GO

CREATE TABLE [dbo].[t_event_log] (
    [id] [int] IDENTITY (1, 1) NOT NULL ,
    [date] [datetime2] NULL ,
    [juchu_no] [char] (10) COLLATE Japanese_CI_AS NOT NULL ,
    [event_id] [int] NULL ,
    [log_text] [varchar] (500) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_event_log] WITH NOCHECK ADD 
    CONSTRAINT [PK_t_event_log] PRIMARY KEY  CLUSTERED 
    (
        [id] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_gazo_site]
GO

CREATE TABLE [dbo].[m_gazo_site] (
    [gazo_category] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [domain] [varchar] (80) COLLATE Japanese_CI_AS NULL ,
    [rerative_path] [varchar] (80) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] (0) NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] (0) NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_gazo_site] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_gazo_site] PRIMARY KEY  CLUSTERED 
    (
        [gazo_category] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_hissu_gazo_kanri]
GO

CREATE TABLE [dbo].[m_hissu_gazo_kanri] (
    [sagyo_type] [char] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_category] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [gazo_type] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [is_required] [int] DEFAULT 0 NULL ,
    [create_date] [datetime2] (0) NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] (0) NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_hissu_gazo_kanri] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_hissu_gazo_kanri] PRIMARY KEY  CLUSTERED 
    (
        [sagyo_type] ,
        [gazo_category] ,
        [gazo_type] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_kizu]
GO

CREATE TABLE [dbo].[m_kizu] (
    [kizu_code] [varchar] (2) COLLATE Japanese_CI_AS NOT NULL ,
    [kizu_name] [varchar] (40) COLLATE Japanese_CI_AS NULL ,
    [has_position] [int] DEFAULT 0 NULL ,
    [priority] [int] NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_kizu] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_kizu] PRIMARY KEY  CLUSTERED 
    (
        [kizu_code] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_help_text]
GO

CREATE TABLE [dbo].[m_help_text] (
    [category_1st] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [category_2nd] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [category_3rd] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [help_text] [varchar] (500) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_help_text] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_help_text] PRIMARY KEY  CLUSTERED 
    (
        [category_1st] ,
        [category_2nd] ,
        [category_3rd] 
    ) ON [PRIMARY] 
GO

DROP TABLE IF EXISTS [m_hanyo]
GO

CREATE TABLE [dbo].[m_hanyo] (
    [hanyo_category] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [hanyo_type] [char] (3) COLLATE Japanese_CI_AS NOT NULL ,
    [hanyo_category_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [hanyo_type_name] [varchar] (100) COLLATE Japanese_CI_AS NULL ,
    [hanyo_type_value] [varchar] (50) COLLATE Japanese_CI_AS NULL ,
    [create_date] [datetime2] NULL ,
    [create_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [create_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [update_date] [datetime2] NULL ,
    [update_user_id] [char] (9) COLLATE Japanese_CI_AS NULL ,
    [update_pg] [varchar] (30) COLLATE Japanese_CI_AS NULL ,
    [is_delete] [int] DEFAULT 0 NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[m_hanyo] WITH NOCHECK ADD 
    CONSTRAINT [PK_m_hanyo] PRIMARY KEY  CLUSTERED 
    (
        [hanyo_category] ,
        [hanyo_type] 
    ) ON [PRIMARY] 
GO
