# AdGuard Home - List

Varied and carefully selected filter lists and consolidates for use in AdGuard Home. (Updated every day at 4 AM)

<!-- vscode-markdown-toc -->
* [How to use this project](#Howtousethisproject)
* [Custom List Provider](#CustomListProvider)
* [External List Provider](#ExternalListProvider)
	* [Contains](#Contains)
		* [Services](#Services)
		* [Community](#Community)

<!-- vscode-markdown-toc-config
	numbering=false
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

## <a name='Howtousethisproject'></a>How to use this project

Once you have AdGuard Home ready and are logged in, use its main menu to add one blocklist and one allowlist.

```sh
# BlockList
https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Block.txt

# AllowList
https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Allow.txt
```

## <a name='CustomListProvider'></a>Custom List Provider

The folders `allowlist/custom/*` and `blocklist/custom/*` contains all custom lists **in AdGuard format**.

## <a name='ExternalListProvider'></a>External List Provider

The external providers are configured in files named like this : `{TYPE}.external.{FORMAT}.list`

```sh
allowlist/
├── custom/
│   ├── *
|   |   └── *.txt
│   └── *
|       └── *.txt
├── external/
│   └── allowlist.external.adguard.list
│   └── allowlist.external.hosts.list
│   └── allowlist.external.pihole.list

blocklist/
├── custom/
│   ├── *
|   |   └── *.txt
│   └── *
|       └── *.txt
├── external/
│   └── blocklist.external.adguard.list
│   └── blocklist.external.hosts.list
│   └── blocklist.external.pihole.list
```

The ***.list** file contains the urls of the external lists to add.

These lists are downloaded, cleaned and combined during a release.

### <a name='Contains'></a>Contains

#### <a name='Services'></a>Services

- [AdGuardSDNSFilter/Filters](https://adguardteam.github.io/AdGuardSDNSFilter/Filters/filter.txt)
- [Adaway](https://adaway.org)
- [EasyList](https://easylist.to)
- [Yoyo.org](https://pgl.yoyo.org/adservers/)
- [firebog.net](https://firebog.net)
- [disconnect.me](https://disconnect.me)
- [phishing.army](https://phishing.army)

#### <a name='Community'></a>Community

- [Curben Urlhaus Filter](https://gitlab.com/curben/urlhaus-filter)
- [frogeye.fr](https://hostfiles.frogeye.fr/)
- [winhelp2002.mvps.org](https://winhelp2002.mvps.org)
- [Hosts.extras](https://github.com/FadeMind/hosts.extras) ![GitHub Repo stars](https://img.shields.io/github/stars/FadeMind/hosts.extras?style=flat-square)
- [StevenBlack/hosts](https://github.com/StevenBlack/hosts) ![GitHub Repo stars](https://img.shields.io/github/stars/StevenBlack/hosts?style=flat-square)
- [anudeepND/blacklist](https://github.com/anudeepND/blacklist) ![GitHub Repo stars](https://img.shields.io/github/stars/anudeepND/blacklist?style=flat-square)
- [notracking/hosts-blocklists](https://github.com/notracking/hosts-blocklists) ![GitHub Repo stars](https://img.shields.io/github/stars/notracking/hosts-blocklists?style=flat-square)
- [mitchellkrogza/Phishing.Database](https://github.com/mitchellkrogza/Phishing.Database) ![GitHub Repo stars](https://img.shields.io/github/stars/mitchellkrogza/Phishing.Database?style=flat-square)
- [Yhonay/antipopads](https://github.com/Yhonay/antipopads) ![GitHub Repo stars](https://img.shields.io/github/stars/Yhonay/antipopads?style=flat-square)
- [mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites](https://github.com/mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites) ![GitHub Repo stars](https://img.shields.io/github/stars/mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites?style=flat-square)