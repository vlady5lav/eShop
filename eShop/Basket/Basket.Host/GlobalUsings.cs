global using System;
global using System.ComponentModel.DataAnnotations;
global using System.Net;
global using System.Reflection;
global using System.Threading.Tasks;

global using EasyNetQ;
global using EasyNetQ.AutoSubscribe;

global using Infrastructure;
global using Infrastructure.Extensions;
global using Infrastructure.Filters;
global using Infrastructure.Identity;
global using Infrastructure.MessageBus;
global using Infrastructure.RateLimit;
global using Infrastructure.Services.Interfaces;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;

global using Order.Host.Configurations;

global using StackExchange.Redis;
