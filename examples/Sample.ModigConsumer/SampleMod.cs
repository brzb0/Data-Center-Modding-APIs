using DataCenter.ModigAPIs;
using MelonLoader;
using UnityEngine.InputSystem;

[assembly: MelonInfo(typeof(Sample.ModigConsumer.SampleMod), "Sample Modig Consumer", "1.0.0", "Cold")]
[assembly: MelonGame("Waseku", "Data Center")]

namespace Sample.ModigConsumer;

public class SampleMod : MelonMod
{
    private bool _fastTime;

    public override void OnInitializeMelon()
    {
        MelonLogger.Msg("Sample.ModigConsumer loaded. Press F1 for help.");
    }

    public override void OnUpdate()
    {
        if (Keyboard.current == null || !ModigGame.IsGameReady())
        {
            return;
        }

        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            ShowHelp();
        }

        if (Keyboard.current.f2Key.wasPressedThisFrame)
        {
            ProbeCoreState();
        }

        if (Keyboard.current.f3Key.wasPressedThisFrame)
        {
            TestPlayerAdd();
        }

        if (Keyboard.current.f4Key.wasPressedThisFrame)
        {
            TestPlayerSet();
        }

        if (Keyboard.current.f5Key.wasPressedThisFrame)
        {
            TestNetworkCounts();
        }

        if (Keyboard.current.f6Key.wasPressedThisFrame)
        {
            TestNetworkBreak();
        }

        if (Keyboard.current.f7Key.wasPressedThisFrame)
        {
            TestNetworkRepair();
        }

        if (Keyboard.current.f8Key.wasPressedThisFrame)
        {
            TestUi();
        }

        if (Keyboard.current.f9Key.wasPressedThisFrame)
        {
            TestLocalisationRead();
        }

        if (Keyboard.current.f10Key.wasPressedThisFrame)
        {
            TestLocalisationChange();
        }

        if (Keyboard.current.f11Key.wasPressedThisFrame)
        {
            TestTime();
        }

        if (Keyboard.current.f12Key.wasPressedThisFrame)
        {
            TestWorld();
        }
    }

    private static void ShowHelp()
    {
        UiApi.TryAddMessage("F2 core | F3 add player | F4 set player | F5 net counts | F6 break | F7 repair | F8 ui | F9 loc read | F10 loc set | F11 time | F12 world");
        MelonLogger.Msg("Help printed to in-game message field.");
    }

    private static void ProbeCoreState()
    {
        var ok = ModigGame.IsGameReady();
        var hasPlayer = ModigGame.GetPlayerRaw() != null;
        var hasMap = ModigGame.GetNetworkMapRaw() != null;
        var hasUi = ModigGame.GetUiRaw() != null;
        var hasTime = ModigGame.GetTimeRaw() != null;
        var hasLoc = ModigGame.GetLocalisationRaw() != null;

        MelonLogger.Msg($"Core: ready={ok} player={hasPlayer} map={hasMap} ui={hasUi} time={hasTime} loc={hasLoc}");
        UiApi.TryAddMessage($"Core ready={ok}, player={hasPlayer}, map={hasMap}, ui={hasUi}, time={hasTime}, loc={hasLoc}");
    }

    private static void TestPlayerAdd()
    {
        var beforeMoney = PlayerApi.GetMoney();
        var beforeXp = PlayerApi.GetXp();
        var beforeRep = PlayerApi.GetReputation();

        var moneyOk = PlayerApi.TryAddMoney(250f, true);
        var xpOk = PlayerApi.TryAddXp(50f);
        var repOk = PlayerApi.TryAddReputation(2f);

        var afterMoney = PlayerApi.GetMoney();
        var afterXp = PlayerApi.GetXp();
        var afterRep = PlayerApi.GetReputation();

        MelonLogger.Msg($"Player add: money {beforeMoney}->{afterMoney}, xp {beforeXp}->{afterXp}, rep {beforeRep}->{afterRep}");
        UiApi.TryAddMessage($"Player add ok: money={moneyOk}, xp={xpOk}, rep={repOk}");
    }

    private static void TestPlayerSet()
    {
        var moneyOk = PlayerApi.TrySetMoney(5000f, true);
        var xpOk = PlayerApi.TrySetXp(1000f);
        var repOk = PlayerApi.TrySetReputation(25f);

        MelonLogger.Msg($"Player set: money={PlayerApi.GetMoney()} xp={PlayerApi.GetXp()} rep={PlayerApi.GetReputation()}");
        UiApi.TryAddMessage($"Player set ok: money={moneyOk}, xp={xpOk}, rep={repOk}");
    }

    private static void TestNetworkCounts()
    {
        var c = NetworkApi.GetCounts();
        var servers = NetworkApi.GetServersSnapshot().Count;
        var switches = NetworkApi.GetSwitchesSnapshot().Count;
        var brokenServers = NetworkApi.GetBrokenServersSnapshot().Count;
        var brokenSwitches = NetworkApi.GetBrokenSwitchesSnapshot().Count;

        MelonLogger.Msg($"Network counts: S {c.BrokenServers}/{c.TotalServers}, SW {c.BrokenSwitches}/{c.TotalSwitches}");
        UiApi.TryAddMessage($"Network snapshot: servers={servers}, switches={switches}, brokenS={brokenServers}, brokenSW={brokenSwitches}");
    }

    private static void TestNetworkBreak()
    {
        var brokeSomething = false;

        var servers = NetworkApi.GetServersSnapshot();
        if (servers.Count > 0)
        {
            brokeSomething |= NetworkApi.TryBreakServer(servers[0]);
        }

        var switches = NetworkApi.GetSwitchesSnapshot();
        if (switches.Count > 0)
        {
            brokeSomething |= NetworkApi.TryBreakSwitch(switches[0]);
        }

        UiApi.TryNotify("Sample SDK: break test executed", -1);
        UiApi.TryAddMessage($"Break test result: {brokeSomething}");
    }

    private static void TestNetworkRepair()
    {
        var fixedCount = NetworkApi.RepairAllBrokenDevices(true);
        var c = NetworkApi.GetCounts();
        MelonLogger.Msg($"Repair all: repaired={fixedCount}");
        UiApi.TryAddMessage($"Repair all fixed={fixedCount}. Remaining broken S={c.BrokenServers}, SW={c.BrokenSwitches}");
    }

    private static void TestUi()
    {
        var notifyOk = UiApi.TryNotify("Sample SDK UI test", -1);
        var messageOk = UiApi.TryAddMessage("Sample SDK message test");
        MelonLogger.Msg($"UI test: notify={notifyOk} message={messageOk}");
    }

    private static void TestLocalisationRead()
    {
        var available = LocalisationApi.IsAvailable();
        var language = LocalisationApi.GetCurrentLanguageName();
        var uid = LocalisationApi.GetCurrentLanguageUid();
        var text0 = LocalisationApi.GetTextById(0);
        var preview = string.IsNullOrEmpty(text0) ? "<empty>" : text0;

        MelonLogger.Msg($"Loc read: available={available} lang={language} uid={uid} text0={preview}");
        UiApi.TryAddMessage($"Loc: {language} uid={uid} text0={preview}");
    }

    private static void TestLocalisationChange()
    {
        var uid = LocalisationApi.GetCurrentLanguageUid();
        var ok = LocalisationApi.TryChangeLanguage(uid);
        MelonLogger.Msg($"Loc change test with same uid={uid}: {ok}");
        UiApi.TryAddMessage($"Loc change test result: {ok} (uid {uid})");
    }

    private void TestTime()
    {
        var day = TimeApi.GetCurrentDay();
        var hour = TimeApi.GetCurrentHour();
        var currentMultiplier = TimeApi.GetTimeMultiplier();
        var inBusinessHours = TimeApi.IsBetween(8f, 20f);

        var target = _fastTime ? 1f : 8f;
        var setOk = TimeApi.TrySetTimeMultiplier(target);
        _fastTime = !_fastTime;

        MelonLogger.Msg($"Time: day={day} hour={hour:F2} mult={currentMultiplier} -> {target}, setOk={setOk}, inBusinessHours={inBusinessHours}");
        UiApi.TryAddMessage($"Time day={day} hour={hour:F1} mult={target} in8to20={inBusinessHours}");
    }

    private static void TestWorld()
    {
        var shops = WorldApi.FindComputerShops();
        var first = WorldApi.FindFirstShopWithNetworkMapScreen();
        var screen = WorldApi.GetNetworkMapScreen();

        var hasFirst = first != null;
        var hasScreen = screen != null;

        MelonLogger.Msg($"World: shops={shops.Count} firstWithScreen={hasFirst} screen={hasScreen}");
        UiApi.TryAddMessage($"World shops={shops.Count}, firstWithScreen={hasFirst}, screen={hasScreen}");
    }
}
