<h1 align="center">
  Safety Test App </br>
  <img src="https://github.com/zulfikar4568/PCI.SafetyTest/actions/workflows/dotnet.yml/badge.svg" />
  <a href="https://github.com/zulfikar4568/PCI.SafetyTest/releases/latest"><img src="https://img.shields.io/github/release/zulfikar4568/PCI.SafetyTest.svg" /></a>
  <a href="https://github.com/zulfikar4568/PCI.SafetyTest/blob/master/LICENSE"><img src="https://img.shields.io/github/license/zulfikar4568/PCI.SafetyTest.svg" /></a>
</h1>

<h1 align="center">
  <img src="https://github.com/zulfikar4568/PCI.SafetyTest/assets/64786139/6db3340e-97e5-47b8-8925-efefd69a700b"/>
  <img src="https://github.com/zulfikar4568/PCI.SafetyTest/assets/64786139/46d8024c-7d04-4e29-8eca-106b1483ceda"/>
</h1>

# Some Notes
```
There's no interlock beetwen tester and MES, let records depend on how many tester doing the test (Actual whether 3x test even more), and operator click Complete if result is pass, and click Rework Request if result is fail (Let Operator will aknowledge that container moved to the Image Test or to rework).

Suggestion: Don't define retest in flow in MES, because: 
1. Safety Test cannot give notification or interlock to the Portal
3. If there's changes of flow, service must be change as well because service need to decide the path whether pass or fail (Flexibility).
```

# Change the Config of the Application
Edit the hosts in your `Endpoints.config`
```config
<endpoint address="https://<your server host>/CamstarWCFServices/DirectAccessService.svc"
```

And Edit the Configuration Application in `App.config`

# Enabled Event Log on windows Machine
- Log on to the computer as an administrator.
- Click Start, click Run, type Regedit in the Open box, and then click OK. - The Registry Editor window appears.
- Locate the following registry subkey
```
Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EventLog
```
- Right-click Eventlog, and then click Permissions. The Permissions for Eventlog dialog box appears.
  
<p align="center">
  <a href="" target="blank"><img src="./Images/EventLogPermission1.jpg" alt="Permission Event Log" /></a>
</p>

- Click Add, add the user account or group that you want and set the following permissions: `Full Control`.

<p align="center">
  <a href="" target="blank"><img src="./Images/EventLogPermission2.jpg" alt="Permission Event Log" /></a>
</p>

- Locate the following registry subkey
```
Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EventLog\Security
```
<p align="center">
  <a href="" target="blank"><img src="./Images/EventLogPermission3.jpg" alt="Permission Event Log" /></a>
</p>

- Click Add, add the user account or group that you want and set the following permissions: `Full Control`.

<p align="center">
  <a href="" target="blank"><img src="./Images/EventLogPermission4.jpg" alt="Permission Event Log" /></a>
</p>

# License & Copy Right
© M. Zulfikar Isnaen, This is Under [MIT License](LICENSE).
