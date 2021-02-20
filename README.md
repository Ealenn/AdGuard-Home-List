# AdGuard Home - List

![](https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/badge-allow.json?style=for-the-badge&logo=firefox)
![](https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/badge-block.json?style=for-the-badge&logo=AdBlock)

Varied and carefully selected filter lists and consolidates for use in AdGuard Home. (Updated every day at 4 AM)

<!-- vscode-markdown-toc -->
* [How to use this project](#Howtousethisproject)
* [Custom List Provider](#CustomListProvider)
* [External List Provider](#ExternalListProvider)
	* [Contains](#Contains)
		* [Services](#Services)
		* [Community](#Community)
* [DNS Providers](#DNSProviders)

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
- [Yhonay/antipopads](https://github.com/Yhonay/antipopads) ![GitHub Repo stars](https://img.shields.io/github/stars/Yhonay/antipopads?style=flat-square)
- [mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites](https://github.com/mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites) ![GitHub Repo stars](https://img.shields.io/github/stars/mitchellkrogza/The-Big-List-of-Hacked-Malware-Web-Sites?style=flat-square)
- [blocklistproject/Lists](https://github.com/blocklistproject/Lists) ![GitHub Repo stars](https://img.shields.io/github/stars/blocklistproject/Lists?style=flat-square)

## <a name='DNSProviders'></a>DNS Providers

```sh
# AdGuard
94.140.14.14
94.140.15.15
https://dns.adguard.com/dns-query
tls://dns.adguard.com
# Google
8.8.8.8
8.8.4.4
https://dns.google/dns-query
tls://dns.google
# Cisco OpenDNS
208.67.222.222
208.67.220.220
https://doh.opendns.com/dns-query
# Cloudflare DNS
1.1.1.1
1.0.0.1
https://dns.cloudflare.com/dns-query
tls://1.1.1.1
# Dyn DNS
216.146.35.35
216.146.36.36
```