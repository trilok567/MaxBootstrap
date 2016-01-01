﻿using MaxBootstrap.Core.Configuration;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.Packages.Features;
using System.Collections.Generic;
using System.Linq;

namespace MaxBootstrap.Core.Helpers
{
    public class PackageFeatureTreeBuilder
    {
        public IEnumerable<IPackage> BuildPackageTrees(IEnumerable<PackageInfo> packageInfos, IEnumerable<FeatureInfo> featureInfos)
        {
            IList<IPackage> packages = new List<IPackage>();

            foreach (var packageInfo in packageInfos)
            {
                var package = this.ProcessPackage(packageInfo, featureInfos.Where(featureInfo => featureInfo.PackageId.Equals(packageInfo.Id)));
                packages.Add(package);
            }

            return packages;
        }

        private IPackage ProcessPackage(PackageInfo packageInfo, IEnumerable<FeatureInfo> featureInfos)
        {
            IPackage package = new Package(packageInfo.Id);

            IDictionary<string, IFeature> featureDictionary = new Dictionary<string, IFeature>();

            foreach (var featureInfo in featureInfos)
            {
                featureDictionary.Add(featureInfo.FeatureId, new Feature(featureInfo.FeatureId, featureInfo.Title, featureInfo.Description, featureInfo.Size));
            }

            foreach (var featureInfo in featureInfos)
            {
                // If there is no parent than the package is the parent, so we just add it
                if (featureInfo.Parent.Equals(string.Empty))
                {
                    package.AddFeature(featureDictionary[featureInfo.FeatureId]);
                }
                else
                {
                    var parentFeature = featureDictionary[featureInfo.Parent];
                    parentFeature.AddSubFeature(featureDictionary[featureInfo.FeatureId]);
                }
            }

            return package;
        }
    }
}
