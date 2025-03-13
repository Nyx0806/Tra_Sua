CREATE TABLE [dbo].[NhanVien] (
    [maNV]      VARCHAR (50) NOT NULL,
    [hoten]     VARCHAR (50) NULL,
    [chucvu]    VARCHAR (50) NULL,
    [luong]     MONEY        NULL,
    [Email]     VARCHAR (50) NULL,
    [sdt]       INT          NULL,
    [TrangThai] VARCHAR (50) NULL,
    [ngaysinh]  DATE         NULL,
    [gioitinh]  BIT          NULL,
    CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([maNV] ASC)
);

