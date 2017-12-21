/world/New(){
	log_world("World loaded at [time_stamp()]");

	SetupExternalRSC();

	GLOB.config_error_log = GLOB.manifest_log = GLOB.world_pda_log = GLOB.sql_error_log = GLOB.world_href_log = GLOB.world_runtime_log = GLOB.world_attack_log = GLOB.world_game_log = file("data/logs/config_error.log");

	CheckSecurityMode();

	make_datum_references_lists();

	new /datum/controller/configuration;

	CheckSchemaVersion();
	SetRoundID();

	SetupLogs();

	ServiceInit();

	load_motd();
	load_admins();
	LoadVerbs(/datum/verbs/menu);
	if(global.config.Get(/datum/config_entry/flag/usewhitelist))
		load_whitelist();
	LoadBans();

	GLOB.timezoneOffset = text2num(time2text(0,"hh")) * 36000;

	if(fexists(RESTART_COUNTER_PATH)){
		GLOB.restart_counter = text2num(trim(file2text(RESTART_COUNTER_PATH)));
		fdel(RESTART_COUNTER_PATH);
	}

	Master.Initialize(10, FALSE);
}