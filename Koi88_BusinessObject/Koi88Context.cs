﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Koi88_BusinessObject;

public partial class Koi88Context : DbContext
{
    public Koi88Context()
    {
    }

    public Koi88Context(DbContextOptions<Koi88Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingPayment> BookingPayments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<KoiFarm> KoiFarms { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<Podetail> Podetails { get; set; }

    public virtual DbSet<Popayment> Popayments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SpecialVariety> SpecialVarieties { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripDetail> TripDetails { get; set; }

    public virtual DbSet<Variety> Varieties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HOA-PC\\HOA;uid=sa;pwd=12345;database=koi;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__46A222CD0B1506E4");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__role_id__5441852A");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__5DE3A5B18438F54C");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.BookingPaymentId).HasColumnName("booking_payment_id");
            entity.Property(e => e.ConsultantId).HasColumnName("consultant_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EstimatedCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("estimatedCost");
            entity.Property(e => e.FavoriteKoi)
                .HasMaxLength(200)
                .HasColumnName("favoriteKoi");
            entity.Property(e => e.Favoritefarm)
                .HasMaxLength(200)
                .HasColumnName("favoritefarm");
            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.HotelAccommodation)
                .HasMaxLength(100)
                .HasColumnName("hotel_accommodation");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .HasColumnName("note");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.PoId).HasColumnName("po_id");
            entity.Property(e => e.QuoteApprovedDate).HasColumnName("quote_approved_date");
            entity.Property(e => e.QuoteSentDate).HasColumnName("quote_sent_date");
            entity.Property(e => e.QuotedAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quoted_amount");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .HasColumnName("status");
            entity.Property(e => e.TripId).HasColumnName("trip_id");

            entity.HasOne(d => d.BookingPayment).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookingPaymentId)
                .HasConstraintName("FK__Booking__booking__5535A963");

            entity.HasOne(d => d.Consultant).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ConsultantId)
                .HasConstraintName("FK__Booking__consult__05D8E0BE");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Booking__custome__5629CD9C");

            entity.HasOne(d => d.Feedback).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK__Booking__feedbac__571DF1D5");

            entity.HasOne(d => d.Po).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PoId)
                .HasConstraintName("FK__Booking__po_id__5812160E");

            entity.HasOne(d => d.Trip).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__Booking__trip_id__59063A47");
        });

        modelBuilder.Entity<BookingPayment>(entity =>
        {
            entity.HasKey(e => e.BookingPaymentId).HasName("PK__BookingP__DB3FBE57720AEBAA");

            entity.ToTable("BookingPayment");

            entity.Property(e => e.BookingPaymentId).HasColumnName("booking_payment_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingPayments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK_BookingPayment_Booking");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.BookingPayments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("fk_bookingpayment_paymentmethod");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB85A4D97599");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Customer__accoun__5BE2A6F2");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__7A6B2B8C520240E5");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .HasColumnName("comments");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Feedbackdate).HasColumnName("feedbackdate");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__custom__5CD6CB2B");
        });

        modelBuilder.Entity<KoiFarm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__KoiFarm__23F321B418775CCB");

            entity.ToTable("KoiFarm");

            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.ContactInfo).HasColumnName("contact_info");
            entity.Property(e => e.FarmName)
                .HasMaxLength(100)
                .HasColumnName("farm_name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__8D4905E70A1AE7ED");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("imageUrl");
            entity.Property(e => e.KoiName)
                .HasMaxLength(100)
                .HasColumnName("koi_name");
            entity.Property(e => e.VarietyId).HasColumnName("variety_id");

            entity.HasOne(d => d.Variety).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("FK__KoiFish__variety__5DCAEF64");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__8A3EA9EB0F942911");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .HasColumnName("method_name");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.HasKey(e => e.PoId).HasName("PK__PO__368DA7F047B2E1C7");

            entity.ToTable("PO");

            entity.Property(e => e.PoId).HasColumnName("po_id");
            entity.Property(e => e.DeliveryLocation)
                .HasMaxLength(200)
                .HasColumnName("Delivery_Location");
            entity.Property(e => e.KoiDeliveryDate).HasColumnName("koi_delivery_date");
            entity.Property(e => e.KoiDeliveryTime).HasColumnName("koi_delivery_time");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
        });

        modelBuilder.Entity<Podetail>(entity =>
        {
            entity.HasKey(e => e.PoDetailId).HasName("PK__PODetail__9E6103B231E1FDF3");

            entity.ToTable("PODetail");

            entity.Property(e => e.PoDetailId).HasColumnName("po_detail_id");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deposit");
            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PoId).HasColumnName("po_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalKoiPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_koi_price");

            entity.HasOne(d => d.Farm).WithMany(p => p.Podetails)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK__PODetail__farm_i__5EBF139D");

            entity.HasOne(d => d.Koi).WithMany(p => p.Podetails)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__PODetail__koi_id__5FB337D6");

            entity.HasOne(d => d.Po).WithMany(p => p.Podetails)
                .HasForeignKey(d => d.PoId)
                .HasConstraintName("FK__PODetail__po_id__60A75C0F");
        });

        modelBuilder.Entity<Popayment>(entity =>
        {
            entity.HasKey(e => e.PoPaymentId).HasName("PK__POPaymen__D958441B337D4353");

            entity.ToTable("POPayment");

            entity.Property(e => e.PoPaymentId).HasColumnName("po_payment_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PoId).HasColumnName("po_id");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Popayments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_POPayment_PO_PaymentMethod");

            entity.HasOne(d => d.Po).WithMany(p => p.Popayments)
                .HasForeignKey(d => d.PoId)
                .HasConstraintName("FK__POPayment__po_id__619B8048");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CCA759CE48");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SpecialVariety>(entity =>
        {
            entity.HasKey(e => e.SpecialVarietyId).HasName("PK__SpecialV__5969FE8D19509EDE");

            entity.ToTable("SpecialVariety");

            entity.Property(e => e.SpecialVarietyId).HasColumnName("special_variety_id");
            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.VarietyId).HasColumnName("variety_id");

            entity.HasOne(d => d.Farm).WithMany(p => p.SpecialVarieties)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK__SpecialVa__farm___6383C8BA");

            entity.HasOne(d => d.Variety).WithMany(p => p.SpecialVarieties)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("FK__SpecialVa__varie__6477ECF3");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trip__302A5D9E60B7AE94");

            entity.ToTable("Trip");

            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.PriceTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_total");
            entity.Property(e => e.TripName)
                .HasMaxLength(100)
                .HasColumnName("trip_name");
        });

        modelBuilder.Entity<TripDetail>(entity =>
        {
            entity.HasKey(e => e.TripDetailId).HasName("PK__TripDeta__FA0AB24258359556");

            entity.ToTable("TripDetail");

            entity.Property(e => e.TripDetailId).HasColumnName("trip_detail_id");
            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.MainTopic)
                .HasMaxLength(200)
                .HasColumnName("main_topic");
            entity.Property(e => e.NotePrice)
                .HasMaxLength(300)
                .HasColumnName("note_price");
            entity.Property(e => e.SubTopic).HasColumnName("sub_topic");
            entity.Property(e => e.TripId).HasColumnName("trip_id");

            entity.HasOne(d => d.Farm).WithMany(p => p.TripDetails)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK_KoiFarm");

            entity.HasOne(d => d.Trip).WithMany(p => p.TripDetails)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_TripDetail_Trip");
        });

        modelBuilder.Entity<Variety>(entity =>
        {
            entity.HasKey(e => e.VarietyId).HasName("PK__Variety__20A0CFC5645CCFDD");

            entity.ToTable("Variety");

            entity.Property(e => e.VarietyId).HasColumnName("variety_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("imageUrl");
            entity.Property(e => e.VarietyName)
                .HasMaxLength(100)
                .HasColumnName("variety_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
