# AdGuard Home - List

![](https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/badge-allow.json&style=for-the-badge&logo=firefox) 
![](https://img.shields.io/endpoint?url=https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/badge-block.json&style=for-the-badge&logo=AdBlock) 

Varied and carefully selected filter lists and consolidates for use in [AdGuard Home](https://ealen.dev/posts/raspberry/dns-sinkhole/). (Updated every day at 4 AM)

- [AdGuard Home - List](#adguard-home---list)
	- [How to use this project](#how-to-use-this-project)
	- [Custom List Provider](#custom-list-provider)
	- [External List Provider](#external-list-provider)
		- [Contains](#contains)
			- [Services](#services)
			- [Community](#community)
			- [AllowList](#allowlist)
	- [DNS Providers](#dns-providers)
	- [Local](#local)

## How to use this project

Once you have AdGuard Home ready and are logged in, use its main menu to add one blocklist and one allowlist.

```sh
# BlockList
https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Block.txt

# AllowList
https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Allow.txt
```

## Custom List Provider

The folders `allowlist/custom/*` and `blocklist/custom/*` contains all custom lists.

## External List Provider

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

### Contains

#### Services

- [AdGuardSDNSFilter/Filters](https://adguardteam.github.io/AdGuardSDNSFilter/Filters/filter.txt)
- [AdguardTeam/cname-trackers](https://github.com/AdguardTeam/cname-trackers) ![GitHub Repo stars](https://img.shields.io/github/stars/AdguardTeam/cname-trackers?style=flat-square)
- [Adaway](https://adaway.org)
- [Yoyo.org](https://pgl.yoyo.org/adservers/)
- [firebog.net](https://firebog.net)
- [disconnect.me](https://disconnect.me)
- [phishing.army](https://phishing.army)

#### Community

- [StevenBlack/hosts](https://github.com/StevenBlack/hosts) ![GitHub Repo stars](https://img.shields.io/github/stars/StevenBlack/hosts?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/StevenBlack/hosts?style=flat-square)
- [crazy-max/WindowsSpyBlocker](https://github.com/crazy-max/WindowsSpyBlocker) ![GitHub Repo stars](https://img.shields.io/github/stars/crazy-max/WindowsSpyBlocker?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/crazy-max/WindowsSpyBlocker?style=flat-square) (Only Spy lists)
- [blocklistproject/Lists](https://github.com/blocklistproject/Lists) ![GitHub Repo stars](https://img.shields.io/github/stars/blocklistproject/Lists?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/blocklistproject/Lists?style=flat-square)
- [anudeepND/blacklist](https://github.com/anudeepND/blacklist) ![GitHub Repo stars](https://img.shields.io/github/stars/anudeepND/blacklist?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/anudeepND/blacklist?style=flat-square)
- [Phishing-Database/Phishing.Database](https://github.com/Phishing-Database/Phishing.Database) ![GitHub Repo stars](https://img.shields.io/github/stars/Phishing-Database/Phishing.Database?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Phishing-Database/Phishing.Database?style=flat-square)
- [FadeMind/hosts.extras](https://github.com/FadeMind/hosts.extras) ![GitHub Repo stars](https://img.shields.io/github/stars/FadeMind/hosts.extras?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/FadeMind/hosts.extras?style=flat-square)
- [Yhonay/antipopads](https://github.com/Yhonay/antipopads) ![GitHub Repo stars](https://img.shields.io/github/stars/Yhonay/antipopads?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Yhonay/antipopads?style=flat-square)
- [Spam404/lists](https://github.com/Spam404/lists) ![GitHub Repo stars](https://img.shields.io/github/stars/Spam404/lists?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Spam404/lists?style=flat-square)
- [Perflyst/PiHoleBlocklist](https://github.com/Perflyst/PiHoleBlocklist) ![GitHub Repo stars](https://img.shields.io/github/stars/Perflyst/PiHoleBlocklist?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Perflyst/PiHoleBlocklist?style=flat-square)
- [Dogino/Discord-Phishing-URLs](https://github.com/Dogino/Discord-Phishing-URLs) ![GitHub Repo stars](https://img.shields.io/github/stars/Dogino/Discord-Phishing-URLs?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/Dogino/Discord-Phishing-URLs?style=flat-square)

#### AllowList
- [hl2guide/AdGuard-Home-Whitelist](https://github.com/hl2guide/AdGuard-Home-Whitelist) ![GitHub Repo stars](https://img.shields.io/github/stars/hl2guide/AdGuard-Home-Whitelist?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/hl2guide/AdGuard-Home-Whitelist?style=flat-square) (Only selected lists)
- [GoodnessJSON/PiHole-Whitelist](https://github.com/GoodnessJSON/PiHole-Whitelist) ![GitHub Repo stars](https://img.shields.io/github/stars/GoodnessJSON/PiHole-Whitelist?style=flat-square) ![GitHub Last Commit](https://img.shields.io/github/last-commit/GoodnessJSON/PiHole-Whitelist?style=flat-square)

## DNS Providers

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

## Local

```sh
node ./modules/cli/dist/main.js generate \
--name AdGuard-Home-List.Allow.txt \
--badge badge-allow.json \
--external ./allowlist/external \
--custom ./allowlist/custom \
--concatExternal ./allowlist/concat \
--convertToAllow true \
--output ./dist

node ./modules/cli/dist/main.js generate \
--name AdGuard-Home-List.Block.txt \
--badge badge-block.json \
--external ./blocklist/external \
--custom ./blocklist/custom \
--concatExternal ./blocklist/concat \
--output ./dist
```
