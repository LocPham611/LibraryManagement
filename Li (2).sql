-- Table for storing book details
CREATE TABLE [dbo].[BookDetails] (
    [CategoryID] NVARCHAR(10) NOT NULL,
    [CategoryName] VARCHAR(15) NOT NULL,
    [BookID] NVARCHAR(10) NOT NULL PRIMARY KEY, -- Primary Key
    [BookTitle] NVARCHAR(60) NOT NULL,
    [AuthorID] CHAR(5) NOT NULL,
    [AuthorName] NVARCHAR(40) NOT NULL,
    [PublisherID] NVARCHAR(10) NOT NULL,
    [PublisherName] NVARCHAR(60) NOT NULL,
    [Year] INT NOT NULL,
    [Quantity] INT NOT NULL CHECK ([Quantity] >= 0),
    [BookStatus] VARCHAR(10) NOT NULL CHECK ([BookStatus] IN ('Available', 'Unavailable')),
    [BookValue] DECIMAL(10, 2) NOT NULL
) ON [PRIMARY];

-- Table for storing reader details
CREATE TABLE [dbo].[ReaderDetails] (
    [ReaderID] NVARCHAR(10) NOT NULL PRIMARY KEY, -- Primary Key
    [ReaderName] NVARCHAR(40) NOT NULL,
    [ReaderAddress] NVARCHAR(60) NOT NULL,
    [ReaderPhoneNumber] CHAR(10) NOT NULL,
    [ReaderEmail] NVARCHAR(50) NOT NULL,
    [ReaderPassword] NVARCHAR(30) NOT NULL,
    [Gender] VARCHAR(10) NOT NULL CHECK ([Gender] IN ('Male', 'Female', 'Other')),
    [AccountStatus] VARCHAR(10) NOT NULL CHECK ([AccountStatus] IN ('Valid', 'Locked'))
) ON [PRIMARY];

-- Table for storing borrowing receipt details
CREATE TABLE [dbo].[BorrowingReceiptDetails] (
    [BorrowingReceiptID] NVARCHAR(10) NOT NULL PRIMARY KEY, -- Primary Key
    [ReaderID] NVARCHAR(10) NOT NULL,
    [ReaderName] NVARCHAR(40) NOT NULL,
    [BorrowingDate] DATE NOT NULL,
    [ReturnDate] DATE NOT NULL,
    [ExtensionOption] VARCHAR(10) CHECK ([ExtensionOption] IN ('Yes', 'No')),
    [ExtensionDaysNumber] INT DEFAULT 0 CHECK ([ExtensionDaysNumber] >= 0),
    [BorrowingReceiptStatus] VARCHAR(10) NOT NULL CHECK ([BorrowingReceiptStatus] IN ('Pending', 'Borrowed', 'Returned', 'Canceled', 'Lated')),
    FOREIGN KEY ([ReaderID]) REFERENCES [ReaderDetails]([ReaderID])
) ON [PRIMARY];

-- Table for storing borrowed books
CREATE TABLE [dbo].[BorrowedBooks] (
    BorrowingReceiptID NVARCHAR(10) NOT NULL,
    BorrowedBookID NVARCHAR(10) NOT NULL,
    BorrowedBookName NVARCHAR(60),
    FOREIGN KEY (BorrowingReceiptID) REFERENCES BorrowingReceiptDetails(BorrowingReceiptID),
    FOREIGN KEY (BorrowedBookID) REFERENCES BookDetails(BookID)
);

-- Cập nhật tự động tên sách khi thêm dữ liệu vào BorrowedBooks
CREATE TRIGGER trg_UpdateBorrowedBookName
ON [dbo].[BorrowedBooks]
AFTER INSERT
AS
BEGIN
    -- Cập nhật tên sách dựa vào ID sách
    UPDATE bb
    SET bb.BorrowedBookName = b.BookTitle
    FROM [dbo].[BorrowedBooks] bb
    INNER JOIN [dbo].[BookDetails] b 
	ON bb.BorrowedBookID = b.BookID
    WHERE bb.BorrowedBookName IS NULL;
END;


-- Table for storing fine receipt details
CREATE TABLE [dbo].[FineReceiptDetails] (
    [FineReceiptID] NVARCHAR(10) NOT NULL PRIMARY KEY, -- Primary Key
    [ReaderID] NVARCHAR(10) NOT NULL,
    [ReaderName] NVARCHAR(40) NOT NULL,
    [BorrowingReceiptID] NVARCHAR(10) NOT NULL,
    [Reason] VARCHAR(20) NOT NULL CHECK ([Reason] IN ('Damage 25%', 'Damage 50%', 'Lost')),
	[LateStatus] VARCHAR(10) NOT NULL CHECK ([LateStatus] IN ('Yes', 'No')),
	[LateDays] INT DEFAULT 0 CHECK (0<= [LateDays] AND [LateDays] <= 10),
    [Fee] DECIMAL(10, 2) NOT NULL,
    [PaymentStatus] VARCHAR(10) NOT NULL CHECK ([PaymentStatus] IN ('Paid', 'Not Paid')),
    FOREIGN KEY ([ReaderID]) REFERENCES [ReaderDetails]([ReaderID]),
    FOREIGN KEY ([BorrowingReceiptID]) REFERENCES [BorrowingReceiptDetails]([BorrowingReceiptID])
) ON [PRIMARY];

-- Chèn dữ liệu vào bảng BorrowedBooks

INSERT INTO [dbo].[BookDetails] ([CategoryID], [CategoryName], [BookID], [BookTitle], [AuthorID], [AuthorName], [PublisherID], [PublisherName], [Year], [Quantity], [BookStatus], [BookValue]) VALUES
(N'TN000', N'Thieu nhi', N'TN101', N'Dế Mèn Phiêu Lưu Ký', N'AU101', N'Tô Hoài', N'PB101', N'NXB Kim Đồng', 1941, 10, N'Available', 45000),
(N'TN000', N'Thieu nhi', N'TN102', N'Cho Tôi Xin Một Vé Đi Tuổi Thơ', N'AU102', N'Nguyễn Nhật Ánh', N'PB102', N'NXB Trẻ', 2008, 8, N'Available', 80000),
(N'TN000', N'Thieu nhi', N'TN103', N'Hoàng Tử Bé', N'AU103', N'Antoine de Saint-Exupéry', N'PB103', N'NXB Hội Nhà Văn', 1943, 7, N'Available', 55000),
(N'TN000', N'Thieu nhi', N'TN104', N'Harry Potter và Hòn Đá Phù Thủy', N'AU104', N'J.K. Rowling', N'PB102', N'NXB Trẻ', 1997, 6, N'Available', 45000),
(N'TN000', N'Thieu nhi', N'TN105', N'Alice ở Xứ Sở Diệu Kỳ', N'AU105', N'Lewis Carroll', N'PB104', N'NXB Văn Học', 1865, 5, N'Available', 30000),
(N'KD000', N'Kinh di', N'KD101', N'IT', N'AU106', N'Stephen King', N'PB103', N'NXB Hội Nhà Văn', 1986, 10, N'Available', 25000),
(N'KD000', N'Kinh di', N'KD102', N'Dracula', N'AU107', N'Bram Stoker', N'PB104', N'NXB Văn Học', 1897, 8, N'Available', 15000),
(N'KD000', N'Kinh di', N'KD103', N'Ngôi Nhà Ma Ám', N'AU108', N'Shirley Jackson', N'PB102', N'NXB Trẻ', 1959, 7, N'Available', 50000),
(N'KD000', N'Kinh di', N'KD104', N'Ký Sinh Thú', N'AU109', N'Hitoshi Iwaaki', N'PB101', N'NXB Kim Đồng', 1988, 6, N'Available', 65000),
(N'KD000', N'Kinh di', N'KD105', N'Căn Hộ Ma', N'AU110', N'Mariko Koike', N'PB104', N'NXB Văn Học', 1991, 5, N'Available', 15000),
(N'TL000', N'Tam ly', N'TL101', N'Đắc Nhân Tâm', N'AU112', N'Dale Carnegie', N'PB105', N'NXB Tổng hợp TP.HCM', 1936, 10, N'Available', 20000),
(N'TL000', N'Tam ly', N'TL102', N'7 Thói Quen Của Người Thành Đạt', N'AU113', N'Stephen R. Covey', N'PB102', N'NXB Trẻ', 1989, 8, N'Available', 25000),
(N'TL000', N'Tam ly', N'TL103', N'Bạn Đắt Giá Bao Nhiêu?', N'AU114', N'Vãn Tình', N'PB104', N'NXB Văn Học', 2018, 7, N'Available', 35000),
(N'TL000', N'Tam ly', N'TL104', N'Dám Nghĩ Lớn', N'AU115', N'David J. Schwartz', N'PB106', N'NXB Lao Động', 1959, 6, N'Available', 30000),
(N'TL000', N'Tam ly', N'TL105', N'Tư Duy Nhanh Và Chậm', N'AU116', N'Daniel Kahneman', N'PB107', N'NXB Thế Giới', 2011, 5, N'Available', 25000),
(N'TC000', N'Tinh cam', N'TC101', N'Cô Gái Đến Từ Hôm Qua', N'AU102', N'Nguyễn Nhật Ánh', N'PB102', N'NXB Trẻ', 1989, 10, N'Available', 60000),
(N'TC000', N'Tinh cam', N'TC102', N'Nhà Giả Kim', N'AU117', N'Paulo Coelho', N'PB104', N'NXB Văn Học', 1988, 8, N'Available', 50000),
(N'TC000', N'Tinh cam', N'TC103', N'Bên Nhau Trọn Đời', N'AU118', N'Cố Mạn', N'PB104', N'NXB Văn Học', 2003, 7, N'Available', 45000),
(N'TC000', N'Tinh cam', N'TC104', N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', N'AU102', N'Nguyễn Nhật Ánh', N'PB102', N'NXB Trẻ', 2010, 6, N'Available', 25000),
(N'TC000', N'Tinh cam', N'TC105', N'Trái Tim Mùa Thu', N'AU119', N'Tân Di Ổ', N'PB104', N'NXB Văn Học', 2007, 5, N'Available', 30000),
(N'BA000', N'Bi an', N'BA101', N'Sherlock Holmes: Tập Truyện Ngắn', N'AU120', N'Arthur Conan Doyle', N'PB104', N'NXB Văn Học', 1892, 10, N'Available', 25000),
(N'BA000', N'Bi an', N'BA102', N'Mật Mã Da Vinci', N'AU121', N'Dan Brown', N'PB102', N'NXB Trẻ', 2003, 8, N'Available', 35000),
(N'BA000', N'Bi an', N'BA103', N'Hỏa Ngục', N'AU122', N'Dan Brown', N'PB104', N'NXB Văn Học', 2013, 7, N'Available', 15000),
(N'BA000', N'Bi an', N'BA104', N'Án Mạng Trên Sông Nile', N'AU123', N'Agatha Christie', N'PB102', N'NXB Trẻ', 1937, 6, N'Available', 10000),
(N'BA000', N'Bi an', N'BA105', N'Vụ Án Bí Ẩn Ở Styles', N'AU123', N'Agatha Christie', N'PB104', N'NXB Văn Học', 1920, 5, N'Available', 50000),
(N'GT000', N'Gia tuong', N'GT101', N'Chúa Tể Những Chiếc Nhẫn', N'AU124', N'J.R.R. Tolkien', N'PB104', N'NXB Văn Học', 1954, 10, N'Available', 35000),
(N'GT000', N'Gia tuong', N'GT102', N'Harry Potter và Tên Tù Nhân Ngục Azkaban', N'AU104', N'J.K. Rowling', N'PB102', N'NXB Trẻ', 1999, 8, N'Available', 15000),
(N'GT000', N'Gia tuong', N'GT103', N'Percy Jackson: Kẻ Cắp Tia Chớp', N'AU125', N'Rick Riordan', N'PB102', N'NXB Trẻ', 2005, 7, N'Available', 20000),
(N'GT000', N'Gia tuong', N'GT104', N'Eragon', N'AU126', N'Christopher Paolini', N'PB104', N'NXB Văn Học', 2002, 6, N'Available', 45000),
(N'GT000', N'Gia tuong', N'GT105', N'Trò Chơi Vương Quyền', N'AU127', N'George R.R. Martin', N'PB102', N'NXB Trẻ', 1996, 5, N'Available', 50000),
(N'LS000', N'Lich su', N'LS101', N'Sapiens: Lược Sử Loài Người', N'AU128', N'Yuval Noah Harari', N'PB107', N'NXB Thế Giới', 2011, 10, N'Available', 35000),
(N'LS000', N'Lich su', N'LS102', N'Lịch Sử Việt Nam', N'AU000', N'Nhiều tác giả', N'PB108', N'NXB Chính Trị Quốc Gia', 2017, 8, N'Available', 70000),
(N'LS000', N'Lich su', N'LS103', N'Bách Khoa Toàn Thư Chiến Tranh', N'AU000', N'Nhiều tác giả', N'PB109', N'NXB Quân Đội', 2015, 7, N'Available', 75000),
(N'LS000', N'Lich su', N'LS104', N'Lược Sử Thời Gian', N'AU129', N'Stephen Hawking', N'PB110', N'NXB Khoa Học', 1988, 6, N'Available', 50000),
(N'LS000', N'Lich su', N'LS105', N'Đại Việt Sử Ký Toàn Thư', N'AU130', N'Ngô Sĩ Liên', N'PB111', N'NXB Giáo Dục', 1697, 5, N'Available', 35000);

INSERT INTO [dbo].[ReaderDetails] ([ReaderID], [ReaderName], [ReaderAddress], [ReaderPhoneNumber], [ReaderEmail], [ReaderPassword], [Gender], [AccountStatus]) VALUES
(N'NDC250000', N'Nguyen Huu Hiep', N'141 Le Van Sy, Ho Chi Minh city', N'0336951234', N'nguyenhuuhiep@example.com', N'HiepDepTraiNhatTrenDoi', N'Male', N'Valid'),
(N'NDC250001', N'Nguyen Van Alabasta', N'278 Le Quang Dinh, Ho Chi Minh city', N'0243374819', N'nguyenvanalabasta@example.com', N'hai1234', N'Male', N'Valid'),
(N'NDC250002', N'Nguyen Vi Kiet', N'456 Nguyen Hue, Ho Chi Minh City', N'0816431871', N'nguyenvikiet@example.com', N'hahahohohihi123', N'Male', N'Valid'),
(N'NDC250003', N'Tran Bao Anh', N'789 Tran Hung Dao, Ho Chi Minh City', N'0842362245', N'tranbaoanh@example.com', N'tranbaoanh789', N'Female', N'Valid'),
(N'NDC250004', N'Le Minh Chi', N'101 Le Duan, Ho Chi Minh City', N'0934252355', N'leminhchi@example.com', N'leminhchi101', N'Male', N'Valid'),
(N'NDC250005', N'Pham Quang Duy', N'202 Hai Ba Trung, Ho Chi Minh City', N'0516714784', N'phamquangduy@example.com', N'phamquangduy201', N'Male', N'Valid'),
(N'NDC250006', N'Hoang Thi Mai', N'303 Pham Ngu Lao, Ho Chi Minh City', N'0241920646', N'hoangthimai@example.com', N'hoangthimai484', N'Female', N'Valid'),
(N'NDC250007', N'Do Thanh Danh', N'404 Bui Vien, Ho Chi Minh City', N'0923461234', N'dothanhdanh@example.com', N'dothanhdanh8238', N'Male', N'Valid'),
(N'NDC250008', N'Nguyen Pham Bao Duy', N'505 Dong Khoi, Ho Chi Minh City', N'0856223566', N'nguyenphambaoduy@example.com', N'nguyenphambaoduy@', N'Male', N'Valid'),
(N'NDC250009', N'Nguyen Binh Nguyen', N'606 Nguyen Thi Minh Khai, Ho Chi Minh City', N'0945746144', N'nguyenbinhnguyen@example.com', N'nguyenbinhnguyen@0911', N'Male', N'Locked'),
(N'NDC250010', N'Luu Manh Hoang', N'707 Vo Van Tan, Ho Chi Minh City', N'0832984214', N'luumanhhoang@example.com', N'luumanhhoang832', N'Male', N'Valid'),
(N'NDC250011', N'Le Huu Chi', N'808 Pasteur, Ho Chi Minh City', N'0723646154', N'lehuuchi@example.com', N'lehuuchi5178', N'Male', N'Valid'),
(N'NDC250012', N'Tran Minh Khoi', N'10 Nguyen Hue, Ho Chi Minh city', N'0901234567', N'tranminhkhoi@example.com', N'khoi12345', N'Male', N'Valid'),
(N'NDC250013', N'Le Thanh Truc', N'11 Đong Khoi, Ho Chi Minh city', N'0918765432', N'lethanhtruc@example.com', N'thanhtrucle123', N'Female', N'Valid'),
(N'NDC250014', N'Luong Gia Hung', N'12 Le Duan, Ho Chi Minh city', N'0983456789', N'luonggiahung@example.com', N'hung82t15', N'Male', N'Valid'),
(N'NDC250015', N'Tran Quoc Khanh', N'13 Tran Hung Đao, Ho Chi Minh city', N'0972345678', N'tranquockhanh@example.com', N'quockhanh2975', N'Male', N'Valid'),
(N'NDC250016', N'Luu Quang Huy', N'14 Nguyen Trai, Ho Chi Minh city', N'0935678910', N'luuquanghuy@example.com', N'quanghuy2414', N'Male', N'Valid'),
(N'NDC250017', N'Nguyen Tram Anh', N'15 Nguyen Thi Minh Khai, Ho Chi Minh city', N'0946789012', N'nguyentramanh@example.com', N'tramanh7761', N'Female', N'Valid'),
(N'NDC250018', N'Dang Huyen Tran', N'16 Cach Mang Thang Tam, Ho Chi Minh city', N'0881234567', N'danghuyentran@example.com', N'huyentran2411', N'Female', N'Valid'),
(N'NDC250019', N'Tran Quoc Anh', N'20 Pham Ngu Lao, Ho Chi Minh city', N'0899876543', N'tranquocanh@example.com', N'quocanh0761', N'Male', N'Valid'),
(N'NDC250020', N'Nguyen Minh Duc', N'21 Le Thanh Ton, Ho Chi Minh city', N'0867654321', N'nguyenminhduc@example.com', N'minhduc5172', N'Male', N'Valid'),
(N'NDC250021', N'Nguyen Quoc Bao', N'22 Nam Ky Khoi Nghia, Ho Chi Minh city', N'0822345678', N'nguyenquocbao@example.com', N'quocbao2242', N'Male', N'Valid'),
(N'NDC250022', N'Pham Hoang Long', N'23Nguyen Van Linh, Ho Chi Minh city', N'0833456789', N'phamhoanglong@example.com', N'hoanglong6652', N'Male', N'Valid'),
(N'NDC250023', N'Tran Cam Tu', N'25 Vo Van Kiet, Ho Chi Minh city', N'0855678910', N'trancamtu@example.com', N'camtu7175', N'Female', N'Valid'),
(N'NDC250024', N'Nguyen Le Thien Phuc', N'30 Vo Van Kiet, Ho Chi Minh city', N'0562789012', N'nguyenlethienphuc@example.com', N'thienphuc0287', N'Male', N'Valid'),
(N'NDC250025', N'Tran Dang Khoa', N'235 Hung Vuong, Ho Chi Minh city', N'0583123456', N'trandangkhoa@example.com', N'dangkhoe0398', N'Male', N'Valid'),
(N'NDC250026', N'Le Huu Tien', N'347Pham Van Đong, Ho Chi Minh city', N'0707890123', N'lehuutien@example.com', N'huutien2341', N'Male', N'Valid'),
(N'NDC250027', N'Nguyen Minh Phuc', N'734 Truong Chinh, Ho Chi Minh city', N'0766543210', N'nguyenminhphuc@example.com', N'minhphuc9012', N'Male', N'Valid'),
(N'NDC250028', N'Nguyen Ngoc Lan Anh', N'173 Xo Viet Nghe Tinh, Ho Chi Minh city', N'0788901234', N'nguyenngoclananh@example.com', N'lananh8716', N'Female', N'Valid'),
(N'NDC250029', N'Le Nhat Minh', N'291 Duong Quang Ham, Ho Chi Minh city', N'0389876543', N'lenhatminh@example.com', N'nhatminh9651', N'Male', N'Valid'),
(N'NDC250030', N'Hoang Phuong Thao', N'361Nguyen Đinh Chieu, Ho Chi Minh city', N'0321234567', N'hoangphuongthao@example.com', N'phuongthao8832', N'Female', N'Valid'),
(N'NDC250031', N'Duong Quang Thien', N'612 Le Hong Phong, Ho Chi Minh city', N'0345678901', N'duongquangthien@example.com', N'quangthien2347', N'Male', N'Valid'),
(N'NDC250032', N'Nguyen Giang Gia Huy', N'13 Bui Vien, Ho Chi Minh city', N'0987107969', N'nguyengianggiahuy@example.com', N'sdf998726', N'Male', N'Valid'),
(N'NDC250033', N'Nguyen Huu Hiep', N'5 Dien Bien Phu, Ho Chi Minh city', N'0968944969', N'nguyenhuuhie1p@example.com', N'wwqf09202', N'Male', N'Valid'),
(N'NDC250034', N'Nguyen Van A', N'12 Nguyen Hue, Ho Chi Minh city', N'0975491369', N'nguyenvana@example.com', N'783526xswd', N'Male', N'Valid'),
(N'NDC250035', N'Trinh Thi Nhung', N'155 Nguyen Van Nghi, Ho Chi Minh city', N'0869388369', N'trinhthinhung@example.com', N'893735scvr', N'Female', N'Valid'),
(N'NDC250036', N'Do Tran Minh Huy', N'78 Nguyen Thi Kieu, Ho Chi Minh city', N'0869388370', N'dotranminhhuy@example.com', N'693563szaas', N'Male', N'Valid'),
(N'NDC250037', N'Vo Dang Khoa', N'100 Xo Viet Nghe Tinh, Ho Chi Minh city', N'0869388371', N'vodangkhoa@example.com', N'475889ffxcbz', N'Male', N'Valid'),
(N'NDC250038', N'Vuong Quoc Cuong', N'30 Phan Dinh Phung, Da Lat city', N'0869388372', N'vuongquoccuong@example.com', N'157234aaszx', N'Male', N'Valid'),
(N'NDC250039', N'Dao Thi Linh', N'50 Ly Thuong Kiet, Phan Thiet city', N'0869388373', N'daothilinh@example.com', N'682531ggzxxcw', N'Female', N'Valid'),
(N'NDC250040', N'Luu Minh Phat', N'68 Truong Chinh, Ho Chi Minh city', N'0869388374', N'luuminhphat@example.com', N'ssfqq098892', N'Male', N'Valid'),
(N'NDC250041', N'Tran Minh', N'899 Lac Long, Ho Chi Minh city', N'0869388375', N'tranminh@example.com', N'ssads957124', N'Male', N'Valid'),
(N'NDC250042', N'Huynh Nghi', N'124 Pham Van Dong, Ho Chi Minh city', N'0869388376', N'huynhnghi@example.com', N'ccsaz947925', N'Male', N'Valid'),
(N'NDC250043', N'Nguyen Xuan Thong', N'41 Le Loi, Ho Chi Minh city', N'0869388377', N'nguyenxuanthong@example.com', N'575326sszzc', N'Male', N'Valid'),
(N'NDC250044', N'Do Duy Nam', N'92 Huyen Tran Cong Chua, Ho Chi Minh city', N'0869388378', N'doduynam@example.com', N'gaaac965960', N'Male', N'Valid'),
(N'NDC250045', N'Nguyen Van Duy', N'101 Ly Thai To, Ho Chi Minh city', N'0869388379', N'nguyenvanduy@example.com', N'ffzdd270945', N'Male', N'Valid'),
(N'NDC250046', N'Do Thi Trang', N'1500 Kha Van Can, Ho Chi Minh city', N'0869388380', N'dothitrang@example.com', N'ddaz357139', N'Female', N'Valid'),
(N'NDC250047', N'Mac Pham Anh Tuan', N'352 Phan Xich Long, Ho Chi Minh city', N'0869388381', N'macphamanhtuan@example.com', N'gghb398267', N'Male', N'Valid'),
(N'NDC250048', N'Hoang Van Hieu', N'394 Thong Nhat, Ho Chi Minh city', N'0869388382', N'hoangvanhieu@example.com', N'xxvb583962', N'Male', N'Valid'),
(N'NDC250049', N'Ha Minh Tri', N'733 Ha Huy Giap, Ho Chi Minh city', N'0869388383', N'haminhtri@example.com', N'153092ssqwr', N'Male', N'Valid'),
(N'NDC250050', N'Truong The Vinh', N'198 Huynh Tan Phat, Ho Chi Minh city', N'0869388384', N'truongthevinh@example.com', N'zzdgv867235', N'Male', N'Valid'),
(N'NDC250051', N'Giang Minh Hai', N'789 Ba Hom, Ho Chi Minh city', N'0869388385', N'giangminhhai@example.com', N'hwh098779', N'Male', N'Valid'),
(N'NDC250052', N'Bao Tien', N'1 Hau Giang, Ho Chi Minh city', N'0869388386', N'baotien@example.com', N'qqqw700564', N'Male', N'Valid'),
(N'TT1234567', N'Librarian', N'Ho Chi Minh city', N'0974800699', N'Li', N'123', N'Other', N'Valid');

INSERT INTO [dbo].[BorrowingReceiptDetails] (BorrowingReceiptID, ReaderID, ReaderName, BorrowingDate, ReturnDate, ExtensionOption, ExtensionDaysNumber, BorrowingReceiptStatus) VALUES
(N'BR000001', N'NDC250000', N'Nguyen Huu Hiep', '2024-03-10', '2024-03-20', N'Yes', 5, N'Returned'),
(N'BR000002', N'NDC250029', N'Le Nhat Minh', '2024-03-11', '2024-03-21', N'No', NULL, N'Returned'),
(N'BR000003', N'NDC250021', N'Nguyen Quoc Bao', '2024-03-12', '2024-03-22', N'Yes', 3, N'Returned'),
(N'BR000004', N'NDC250044', N'Do Duy Nam', '2024-03-13', '2024-03-23', N'No', NULL, N'Returned'),
(N'BR000005', N'NDC250040', N'Luu Minh Phat', '2024-03-14', '2024-03-24', N'No', NULL, N'Returned'),
(N'BR000006', N'NDC250047', N'Mac Pham Anh Tuan', '2024-03-15', '2024-03-25', N'No', NULL, N'Returned'),
(N'BR000007', N'NDC250043', N'Nguyen Xuan Thong', '2024-03-16', '2024-03-26', N'No', NULL, N'Returned'),
(N'BR000008', N'NDC250051', N'Giang Minh Hai', '2024-03-17', '2024-03-27', N'No', NULL, N'Returned'),
(N'BR000009', N'NDC250009', N'Nguyen Binh Nguyen', '2024-03-18', '2024-03-28', N'Yes', 1, N'Returned'),
(N'BR000010', N'NDC250019', N'Tran Quoc Anh', '2024-03-19', '2024-03-29', N'No', NULL, N'Returned'),
(N'BR000011', N'NDC250000', N'Nguyen Huu Hiep', '2024-03-20', '2024-03-30', N'Yes', 3, N'Returned'),
(N'BR000012', N'NDC250046', N'Do Thi Trang', '2024-03-21', '2024-03-31', N'No', NULL, N'Returned'),
(N'BR000013', N'NDC250024', N'Nguyen Le Thien Phuc', '2024-03-22', '2024-04-01', N'No', NULL, N'Borrowed'),
(N'BR000014', N'NDC250035', N'Trinh Thi Nhung', '2024-03-23', '2024-04-02', N'Yes', 5, N'Borrowed'),
(N'BR000015', N'NDC250052', N'Bao Tien', '2024-03-24', '2024-04-03', N'No', NULL, N'Borrowed'),
(N'BR000016', N'NDC250008', N'Nguyen Pham Bao Duy', '2024-03-25', '2024-04-04', N'No', NULL, N'Borrowed'),
(N'BR000017', N'NDC250024', N'Nguyen Le Thien Phuc', '2024-03-26', '2024-04-05', N'No', NULL, N'Borrowed'),
(N'BR000018', N'NDC250036', N'Do Tran Minh Huy', '2024-03-27', '2024-04-06', N'No', NULL, N'Borrowed'),
(N'BR000019', N'NDC250019', N'Tran Quoc Anh', '2024-03-28', '2024-04-07', N'Yes', 4, N'Borrowed'),
(N'BR000020', N'NDC250026', N'Le Huu Tien', '2024-03-29', '2024-04-08', N'No', NULL, N'Borrowed'),
(N'BR000021', N'NDC250008', N'Nguyen Pham Bao Duy', '2025-03-13', '2025-03-25', N'Yes', 5, N'Returned'),
(N'BR000022', N'NDC250033', N'Nguyen Huu Hiep', '2025-03-15', '2025-03-22', N'No', NULL, N'Returned'),
(N'BR000023', N'NDC250050', N'Truong The Vinh', '2025-03-19', '2025-03-26', N'No', NULL, N'Returned'),
(N'BR000024', N'NDC250052', N'Bao Tien', '2025-02-28', '2025-03-07', N'No', NULL, N'Returned'),
(N'BR000025', N'NDC250013', N'Le Thanh Truc', '2025-02-24', '2025-03-06', N'Yes', 3, N'Returned'),
(N'BR000026', N'NDC250035', N'Trinh Thi Nhung', '2025-02-24', '2025-03-03', N'No', NULL, N'Returned'),
(N'BR000027', N'NDC250022', N'Pham Hoang Long', '2025-03-14', '2025-03-26', N'Yes', 5, N'Returned'),
(N'BR000028', N'NDC250004', N'Le Minh Chi', '2025-02-18', '2025-02-25', N'No', NULL, N'Returned'),
(N'BR000029', N'NDC250027', N'Nguyen Minh Phuc', '2025-03-17', '2025-03-25', N'Yes', 1, N'Returned'),
(N'BR000030', N'NDC250043', N'Nguyen Xuan Thong', '2025-02-19', '2025-03-02', N'Yes', 4, N'Returned');

INSERT INTO [dbo].[BorrowedBooks] (BorrowingReceiptID, BorrowedBookID) VALUES
(N'BR000001', N'TN104'), (N'BR000001', N'KD104'), (N'BR000001', N'TL105'),  
(N'BR000002', N'TN105'),  
(N'BR000003', N'KD104'),  
(N'BR000004', N'TN102'),  
(N'BR000005', N'GT101'),
(N'BR000006', N'KD104'),  
(N'BR000007', N'TN102'),  
(N'BR000008', N'GT101'),  
(N'BR000009', N'TN103'),  
(N'BR000010', N'TN104'),  
(N'BR000011', N'KD103'),  
(N'BR000012', N'TC102'),  
(N'BR000013', N'KD103'),  
(N'BR000014', N'BA104'),  
(N'BR000015', N'BA105'),  
(N'BR000016', N'KD102'),  
(N'BR000017', N'KD102'),  
(N'BR000018', N'LS105'),  
(N'BR000019', N'TL103'),  
(N'BR000020', N'TC102'),  
(N'BR000021', N'TC104'), (N'BR000021', N'GT104'), (N'BR000021', N'TL102'),  
(N'BR000022', N'BA101'), (N'BR000022', N'TN105'), (N'BR000022', N'TL104'),  
(N'BR000023', N'KD103'),  
(N'BR000024', N'TC102'),  
(N'BR000025', N'TL104'), (N'BR000025', N'TN104'), (N'BR000025', N'BA105'),  
(N'BR000026', N'KD103'), (N'BR000026', N'BA101'), (N'BR000026', N'TL102'),  
(N'BR000027', N'LS105'), (N'BR000027', N'LS102'), (N'BR000027', N'BA103'),  
(N'BR000028', N'LS101'), (N'BR000028', N'TN105'), (N'BR000028', N'BA104'),  
(N'BR000029', N'BA102'), (N'BR000029', N'GT104'),  
(N'BR000030', N'GT101');

INSERT INTO [dbo].[FineReceiptDetails] ([FineReceiptID], [ReaderID], [ReaderName], [BorrowingReceiptID], [Reason], [LateStatus], [LateDays], [Fee], [PaymentStatus]) VALUES
(N'FR2500001', N'NDC250035', N'Trinh Thi Nhung', N'BR000014', N'Damage 25%', N'No', 0, 25000, N'Not Paid'),
(N'FR2500002', N'NDC250009', N'Nguyen Binh Nguyen', N'BR000009', N'Damage 25%', N'Yes', 10, 117500, N'Not Paid'),
(N'FR2500003', N'NDC250008', N'Nguyen Pham Bao Duy', N'BR000021', N'Lost', N'No', 0, 105000, N'Not Paid'),
(N'FR2500004', N'NDC250022', N'Pham Hoang Long', N'BR000027', N'Damage 50%', N'No', 0, 60000, N'Not Paid'),
(N'FR2500005', N'NDC250052', N'Bao Tien', N'BR000015', N'Lost', N'No', 0, 50000, N'Not Paid'),
(N'FR2500006', N'NDC250019', N'Tran Quoc Anh', N'BR000010', N'Damage 50%', N'No', 0, 22500, N'Not Paid'),
(N'FR2500007', N'NDC250033', N'Nguyen Huu Hiep', N'BR000022', N'Damage 25%', N'No', 0, 21250, N'Not Paid'),
(N'FR2500008', N'NDC250000', N'Nguyen Huu Hiep', N'BR000001', N'Lost', N'No', 0, 45000, N'Not Paid');

ALTER TABLE BookDetails
ADD ImagePath NVARCHAR(255) NULL;

ALTER TABLE BookDetails ALTER COLUMN BookStatus VARCHAR(20);
