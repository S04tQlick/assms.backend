global using Asp.Versioning;
global using Microsoft.AspNetCore.Mvc;
global using Serilog;
global using Serilog.Core;
global using Serilog.Events;
global using System.Reflection;

global using Bogus;

global using System.Linq.Expressions;
global using Microsoft.EntityFrameworkCore.Query;

global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using assms.entities.Response.AuthResponse;
global using Microsoft.Extensions.Options;

global using System.Net;
global using System.Net.Mail;
global using Npgsql;

global using System.Text;
global using assms.api.DAL.Data.DatabaseSeeder;
global using assms.api.DAL.DatabaseContext;
global using assms.api.DAL.QueryHandlers;
global using assms.api.DAL.Repositories.AssetCategoryRepository;
global using assms.api.DAL.Repositories.AssetRepository;
global using assms.api.DAL.Repositories.AssetTypeRepository;
global using assms.api.DAL.Repositories.AuthRepository;
global using assms.api.DAL.Repositories.BranchRepository;
global using assms.api.DAL.Repositories.CustomAuthorization;
global using assms.api.DAL.Repositories.InstitutionRepository;
global using assms.api.DAL.Repositories.UserRepository;
global using assms.api.DAL.Repositories.VendorRepository;
global using assms.api.DAL.Services.AssetCategoryService;
global using assms.api.DAL.Services.AssetService;
global using assms.api.DAL.Services.AssetTypeService;
global using assms.api.DAL.Services.AuthServices;
global using assms.api.DAL.Services.BranchService;
global using assms.api.DAL.Services.InstitutionService;
global using assms.api.DAL.Services.UserService;
global using assms.api.DAL.Services.VendorService;
global using assms.api.Helpers;
global using assms.api.Middlewares;
global using assms.entities.Config;
global using assms.entities.Models;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using StackExchange.Redis;

global using assms.api.Constants;

global using Microsoft.AspNetCore.Identity.Data;

global using assms.entities.GeneralResponse;
global using assms.entities.Request;
global using assms.entities.Response.AssetCategoryResponse;

global using assms.entities.Enums;
global using assms.entities.Response.InstitutionsResponse;
global using assms.entities.Response.AssetResponse;
global using assms.entities.Response.AssetTypeResponse;
global using assms.entities.Response.BranchResponse;
global using assms.entities.Response.UserResponse;
global using assms.entities.Response.VendorResponse;