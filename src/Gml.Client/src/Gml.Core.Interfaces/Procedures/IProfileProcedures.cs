﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Gml.Web.Api.Domains.System;
using GmlCore.Interfaces.Bootstrap;
using GmlCore.Interfaces.Enums;
using GmlCore.Interfaces.Launcher;
using GmlCore.Interfaces.Mods;
using GmlCore.Interfaces.System;
using GmlCore.Interfaces.User;

namespace GmlCore.Interfaces.Procedures
{
    public interface IProfileProcedures
    {
        public delegate void ProgressPackChanged(ProgressChangedEventArgs e);

        IObservable<double> PackChanged { get; }
        IObservable<int> ProfilesChanged { get; }
        Task AddProfile(IGameProfile? profile);

        Task<IGameProfile?> AddProfile(string name, string displayName, string version, string loaderVersion,
            GameLoader loader,
            string profileIconBase64,
            string description);

        Task<bool> CanAddProfile(string name, string version, string loaderVersion, GameLoader dtoGameLoader);
        Task RemoveProfile(IGameProfile profile);
        Task RemoveProfile(IGameProfile profile, bool removeProfileFiles);
        Task RestoreProfiles();
        Task RemoveProfile(int profileId);
        Task ClearProfiles();
        Task<bool> ValidateProfileAsync(IGameProfile baseProfile);
        bool ValidateProfile();
        Task SaveProfiles();
        Task DownloadProfileAsync(IGameProfile baseProfile, IBootstrapProgram? version = default);
        Task<IEnumerable<IFileInfo>> GetProfileFiles(IGameProfile baseProfile);
        Task<IGameProfile?> GetProfile(string profileName);
        Task<IEnumerable<IGameProfile>> GetProfiles();
        Task<IGameProfileInfo?> GetProfileInfo(string profileName, IStartupOptions startupOptions, IUser user);
        Task<IGameProfileInfo?> RestoreProfileInfo(string profileName);
        Task PackProfile(IGameProfile baseProfile);
        Task AddFileToWhiteList(IGameProfile profile, IFileInfo file);
        Task RemoveFileFromWhiteList(IGameProfile profile, IFileInfo file);
        Task UpdateProfile(IGameProfile profile, string newProfileName, string displayName, Stream? icon,
            Stream? backgroundImage,
            string updateDtoDescription, bool isEnabled,
            string jvmArguments, string gameArguments);
        Task<string[]> InstallAuthLib(IGameProfile profile);
        Task<IGameProfileInfo?> GetCacheProfile(IGameProfile baseProfile);
        Task SetCacheProfile(IGameProfileInfo profile);
        Task CreateModsFolder(IGameProfile profile);
        Task<ICollection<IFileInfo>> GetProfileFiles(IGameProfile profile, string osName, string osArchitecture);
        Task<IFileInfo[]> GetAllProfileFiles(IGameProfile baseProfile, bool needRestoreCache);
        Task<IFileInfo[]> GetModsAsync(IGameProfile baseProfile);
        Task<IFileInfo[]> GetOptionalsModsAsync(IGameProfile baseProfile);
        Task<IEnumerable<string>> GetAllowVersions(GameLoader result, string? minecraftVersion);
        Task ChangeBootstrapProgram(IGameProfile testGameProfile, IBootstrapProgram version);
        Task AddFolderToWhiteList(IGameProfile profile, IFolderInfo folder);
        Task RemoveFolderFromWhiteList(IGameProfile profile, IFolderInfo folder);
        Task RemoveFolderFromWhiteList(IGameProfile profile, IEnumerable<IFolderInfo> folders);
        Task AddFolderToWhiteList(IGameProfile profile, IEnumerable<IFolderInfo> folders);
        Task CreateUserSessionAsync(IGameProfile profile, IUser user);
        Task<IMod> AddMod(IGameProfile profile, string fileName, Stream streamData);
        Task<IMod> AddOptionalMod(IGameProfile profile, string fileName, Stream streamData);
        Task<bool> RemoveMod(IGameProfile profile, string modName);
    }
}
