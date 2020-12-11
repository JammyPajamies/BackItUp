﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BackItUp.Models.Validation
{
    static class BackupItemValidation
    {
        /// <summary>
        /// Validates that the directory or file at the given origin path exists and is different from the backup path.
        /// </summary>
        /// <param name="originPath"></param>
        /// <param name="backupPath"></param>
        /// <returns></returns>
        public static string ValidateOriginPath(string originPath, string backupPath)
        {
            //Debug.WriteLine(string.Format("ValidateOriginPath checking {0} and {1}", originPath, backupPath));

            if (!(Directory.Exists(originPath) ||
                File.Exists(originPath)))
            {
                return "Origin path is invalid.";
            }

            return null;
        }

        /// <summary>
        /// Validates that the directory at the given backup path exists and is different from the origin path.
        /// </summary>
        /// <param name="originPath"></param>
        /// <param name="backupPath"></param>
        /// <returns></returns>
        public static string ValidateBackupPath(string originPath, string backupPath)
        {
            //Debug.WriteLine(string.Format("ValidateBackupPath checking {0} and {1}", originPath, backupPath));

            if (!(!string.IsNullOrEmpty(backupPath) &&
                Directory.Exists(backupPath)))
            {
                return "Backup path is invalid.";
            }

            if (originPath == backupPath)
            {
                return "Origin and backup paths are the same. They must be different.";
            }

            return null;
        }

        /// <summary>
        /// Validator for frequency of backups.
        /// </summary>
        /// <param name="frequencyAsString"></param>
        /// <returns></returns>
        public static string ValidateBackupFrequency(string frequencyAsString)
        {
            int temp;

            if(frequencyAsString != null &&
               frequencyAsString.Length >= 0 &&
               frequencyAsString.Length < 4 &&
               int.TryParse(frequencyAsString, out temp))
            {
                return null;
            }

            return "Backup Frequency must be 1-3 digit integer.";
        }
    }
}
