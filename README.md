# AdGuard Home - List

Varied and carefully selected filter lists and consolidates for use in AdGuard Home. (Updated every day at 4 AM)

<!-- vscode-markdown-toc -->
* [How to use this project](#Howtousethisproject)
* [Custom List Provider](#CustomListProvider)
* [External List Provider](#ExternalListProvider)
	* [Contains](#Contains)

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

- [AdGuardSDNSFilter/Filters](https://adguardteam.github.io/AdGuardSDNSFilter/Filters/filter.txt)
- [Adaway](https://adaway.org)
- [EasyList](https://easylist.to)
- [Yoyo.org](https://pgl.yoyo.org/adservers/)
- [YouTube Ads4Pi-Hole](https://github.com/kboghdady/youTube_ads_4_pi-hole) ![GitHub Repo stars](https://img.shields.io/github/stars/kboghdady/youTube_ads_4_pi-hole?style=flat-square)
- [Curben Urlhaus Filter](https://gitlab.com/curben/urlhaus-filter)
- [Hosts.extras](https://github.com/FadeMind/hosts.extras) ![GitHub Repo stars](https://img.shields.io/github/stars/FadeMind/hosts.extras?style=flat-square)
- [StevenBlack/hosts](https://github.com/StevenBlack/hosts) ![GitHub Repo stars](https://img.shields.io/github/stars/StevenBlack/hosts?style=flat-square)
- [anudeepND/blacklist](https://github.com/anudeepND/blacklist) ![GitHub Repo stars](https://img.shields.io/github/stars/anudeepND/blacklist?style=flat-square)
- [firebog.net](https://firebog.net)
- [disconnect.me](https://disconnect.me)
- [phishing.army](https://phishing.army)
- [winhelp2002.mvps.org](https://winhelp2002.mvps.org)
- [Shub_/mobile-ads-block](https://gitlab.com/Shub_/mobile-ads-block)