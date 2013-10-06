﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

using Terraria.Plugins.Common;

using TShockAPI;
using Newtonsoft.Json;

namespace Terraria.Plugins.CoderCow.Protector {
  public class RefillChestMetadata {
    #region [Property: Owner]
    private int owner;

    public int Owner {
      get { return this.owner; }
      set { this.owner = value; }
    }
    #endregion

    #region [Property: RefillItems]
    private ItemData[] refillItems;

    public ItemData[] RefillItems {
      get { return this.refillItems; }
      set { this.refillItems = value; }
    }
    #endregion

    #region [Property: RefillTimer, RefillStartTime, RefillTime]
    private Timer refillTimer;

    [JsonIgnore]
    public Timer RefillTimer {
      get { return this.refillTimer; }
      set {
        Contract.Requires<ArgumentNullException>(value != null);
        this.refillTimer = value;
      }
    }

    public DateTime RefillStartTime {
      get { return this.RefillTimer.StartTime; }
      set { this.RefillTimer.StartTime = value; }
    }

    public TimeSpan RefillTime {
      get { return this.RefillTimer.TimeSpan; }
    }
    #endregion

    #region [Property: OneLootPerPlayer]
    private bool oneLootPerPlayer;

    public bool OneLootPerPlayer {
      get { return this.oneLootPerPlayer; }
      set { this.oneLootPerPlayer = value; }
    }
    #endregion

    #region [Property: LootLimit]
    private int remainingLoots;

    public int RemainingLoots {
      get { return this.remainingLoots; }
      set { this.remainingLoots = value; }
    }
    #endregion

    #region [Property: Looters]
    private Collection<int> looters;

    public Collection<int> Looters {
      get { return this.looters; }
      set { this.looters = value; }
    }
    #endregion

    #region [Property: AutoLock]
    private bool autoLock;

    public bool AutoLock {
      get { return this.autoLock; }
      set { this.autoLock = value; }
    }
    #endregion


    #region [Method: Constructor]
    public RefillChestMetadata(int owner): base() {
      this.owner = owner;
      this.refillItems = new ItemData[Chest.maxItems];
      this.refillTimer = new Timer(TimeSpan.Zero, null, null);
      this.remainingLoots = -1;
    }
    #endregion
  }
}
